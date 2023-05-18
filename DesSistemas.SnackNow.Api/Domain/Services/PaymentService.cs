using DesSistemas.SnackNow.Api.Domain.Entities;
using DesSistemas.SnackNow.Api.Domain.Repositories.Interfaces;
using DesSistemas.SnackNow.Api.Domain.Services.Interfaces;
using DesSistemas.SnackNow.Api.Dto.Payment;
using DesSistemas.SnackNow.Api.Integrations.Pagarme.Interfaces;
using DesSistemas.SnackNow.Startup.Exceptions;

namespace DesSistemas.SnackNow.Api.Domain.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentsRepository _paymentsRepository;
        private readonly IPagarmeIntegration _pagarmeIntegration;

        public PaymentService(IPaymentsRepository paymentsRepository, IPagarmeIntegration pagarmeIntegration)
        {
            _paymentsRepository = paymentsRepository;
            _pagarmeIntegration = pagarmeIntegration;
        }

        public async Task<PaymentAddResponse> GenerateQrCodeAsync(PaymentAddRequest add)
        {
            //TODO: VALIDAR CAMPOS

            var result = await _pagarmeIntegration.CreateOrderAsync(new Integrations.Pagarme.Dto.PagarmeOrderRequest
            {
                Customer = new Integrations.Pagarme.Dto.Customer
                {
                    Document = add.Cpf,
                    DocumentType = "CPF",
                    Name = add.Name,
                    Phones = new Integrations.Pagarme.Dto.Phones
                    {
                        HomePhone = new Integrations.Pagarme.Dto.HomePhone
                        {
                            CountryCode = "55",
                            AreaCode = add.CellPhone.Substring(0, 2),
                            Number = add.CellPhone.Substring(2, add.CellPhone.Length - 2)
                        }
                    },
                    Type = "individual"
                },
                Items = new List<Integrations.Pagarme.Dto.Item>
                {
                    new Integrations.Pagarme.Dto.Item
                    {
                        Amount = Convert.ToInt32(add.Value * 100),
                        Quantity = 1,
                        Description = "Pagamento Doacao"
                    }
                },
                Payments = new List<Integrations.Pagarme.Dto.Payment>
                {
                    new Integrations.Pagarme.Dto.Payment
                    {
                        PaymentMethod = "pix",
                        Pix = new Integrations.Pagarme.Dto.Pix
                        {
                            ExpiresIn = 360
                        }
                    }
                }
            });


            var entity = new Payments
            {
                OrderId = result.Id,
                QrCode = result.Charges.First().LastTransaction.QrCode,
                QrCodeUrl = result.Charges.First().LastTransaction.QrCodeUrl,
                PayerCellphone = add.CellPhone,
                PayerDocument = add.Cpf,
                PayerName = add.Name,
                Status = Enums.PaymentStatus.Pending,
                ValuePaid = add.Value,
                DonationRequestId = add.DonationRequestId
            };

            await _paymentsRepository.AddAsync(entity);
            
            return new PaymentAddResponse
            {
                QrCodeUrl = entity.QrCodeUrl,
                DonationRequestId = entity.DonationRequestId,
                PaymentId = entity.Id
            };
        }

        public async Task<ValidatePaymentResponse> ValidatePaymentAsync(ValidatePaymentRequest dto)
        {
            var payment = await _paymentsRepository.GetByIdAsync(dto.PaymentId, tracking: true);
            if (payment is null || payment.DonationRequestId != dto.DonationRequestId)
                throw new HttpNotFoundException("Pagamento não encontrado.");

            if (payment.Status == Enums.PaymentStatus.Paid)
                return new ValidatePaymentResponse { IsPaid = true };

            var paymentResult = await _pagarmeIntegration.GetOrderByIdAsync(payment.OrderId);
            var resultPayment = paymentResult.Charges.FirstOrDefault()?.LastTransaction;

            if (resultPayment is null)
                throw new HttpNotFoundException("Pagamento não encontrado.");

            if (resultPayment.Status == "paid")
            {
                payment.Status = Enums.PaymentStatus.Paid;
                payment.EndToEndId = resultPayment.EndToEndId;
                await _paymentsRepository.UpdateAsync(payment);
            }
            else if (resultPayment.Status != "pending")
            {
                payment.Status = Enums.PaymentStatus.Canceled;
                await _paymentsRepository.UpdateAsync(payment);
            }

            return new ValidatePaymentResponse
            {
                IsPaid = payment.Status == Enums.PaymentStatus.Paid
            };
        }
    }
}