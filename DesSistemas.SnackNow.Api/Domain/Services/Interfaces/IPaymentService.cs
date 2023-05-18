using DesSistemas.SnackNow.Api.Dto.Payment;

namespace DesSistemas.SnackNow.Api.Domain.Services.Interfaces
{
    public interface IPaymentService
    {
        Task<PaymentAddResponse> GenerateQrCodeAsync(PaymentAddRequest add);
        Task<ValidatePaymentResponse> ValidatePaymentAsync(ValidatePaymentRequest dto);
    }
}