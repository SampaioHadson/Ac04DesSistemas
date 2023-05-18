namespace DesSistemas.SnackNow.Api.Dto.Payment
{
    public class ValidatePaymentRequest
    {
        public long DonationRequestId { get; set; }
        public long PaymentId { get; set; }
    }
}