namespace DesSistemas.SnackNow.Api.Dto.DonationRequests
{
    public class DonationRequestListDto
    {
        public string AnimalName { get; set; }
        public string Description { get; set; }
        public decimal AmountToRaise { get; set; }
        public long Id { get; set; }
        public decimal Total { get; set; }
    }
}
