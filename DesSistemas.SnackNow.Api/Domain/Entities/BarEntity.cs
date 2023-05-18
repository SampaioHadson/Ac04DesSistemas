using DesSistemas.SnackNow.Startup.ApiLayers.Database;

namespace DesSistemas.SnackNow.Api.Domain.Entities
{
    public class BarEntity : EntityBase<long>
    {
        public string Name { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}