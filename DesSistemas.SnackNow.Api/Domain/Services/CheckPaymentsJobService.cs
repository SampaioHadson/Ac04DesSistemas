using DesSistemas.SnackNow.Api.Domain.Repositories.Interfaces;
using DesSistemas.SnackNow.Api.Domain.Services.Interfaces;

namespace DesSistemas.SnackNow.Api.Domain.Services
{
    public class CheckPaymentsJobService : ICheckPaymentsJobService
    {
        private readonly IPaymentService _paymentService;
        private readonly IPaymentsRepository _paymentsRepository;

        public CheckPaymentsJobService(IPaymentsRepository paymentsRepository, IPaymentService paymentService)
        {
            _paymentsRepository = paymentsRepository;
            _paymentService = paymentService;
        }

        public async Task RunAsync()
        {
            var pendingPayments = await _paymentsRepository.GetAllToValidade();
            foreach (var payment in pendingPayments)
            {
                await _paymentService.ValidatePaymentAsync(new Dto.Payment.ValidatePaymentRequest
                {
                    DonationRequestId = payment.DonationRequestId,
                    PaymentId = payment.Id
                });
            }
        }
    }
}