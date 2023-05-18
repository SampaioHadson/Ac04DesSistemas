namespace DesSistemas.SnackNow.Api.Dto.Payment
{
    public class PaymentAddRequest
    {
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string CellPhone { get; set; }
        public decimal Value { get; set; }
        public long DonationRequestId { get; set; }
    }
}