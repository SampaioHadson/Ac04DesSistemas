namespace DesSistemas.SnackNow.Api.Dto.Payment
{
    public class PaymentAddResponse
    {
        public string QrCodeUrl { get; set; }
        public long PaymentId { get; set; }
        public long DonationRequestId { get; set; }
    }
}