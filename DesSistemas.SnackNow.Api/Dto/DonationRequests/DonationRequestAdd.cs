namespace DesSistemas.SnackNow.Api.Dto.DonationRequests
{
    public class DonationRequestAdd
    {
        public string AnimalName { get; set; }
        public string Description { get; set; }
        public decimal AmountToRaise { get; set; }
        public string ImageBase64 { get; set; }
    }
}
