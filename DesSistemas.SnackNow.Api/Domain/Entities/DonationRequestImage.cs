using DesSistemas.SnackNow.Startup.ApiLayers.Database;

namespace DesSistemas.SnackNow.Api.Domain.Entities
{
    public class DonationRequestImage : EntityBase<long>
    {
        public DonationRequest DonationRequest { get; set; }
        public long DonationRequestId { get; set; }
        public string ImageBase64 { get; set; }
    }
}