using DesSistemas.SnackNow.Startup.ApiLayers.Database;

namespace DesSistemas.SnackNow.Api.Domain.Entities
{
    public class DonationRequest : EntityBase<long>
    {
        public string AnimalName { get; set; }
        public string Description { get; set; }
        public decimal AmountToRaise { get; set; }
        public DonationRequestImage DonationRequestImage { get; set; }
    }
}