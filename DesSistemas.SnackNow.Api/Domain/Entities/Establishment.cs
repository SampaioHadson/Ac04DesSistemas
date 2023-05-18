using DesSistemas.SnackNow.Api.Dto.Establishments;
using DesSistemas.SnackNow.Startup.ApiLayers.Database;

namespace DesSistemas.SnackNow.Api.Domain.Entities
{
    public class Establishment : EntityBase<long>
    {
        public long? AddressId { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public IndividualAddress? Address { get; set; }

        public Establishment() { }

        public Establishment(EstablishmentAddRequest request)
        {
            Name = request.Name;
            Description = request.Description;
        }

        public void Update(EstablishmentAddRequest request)
        {
            Name = request.Name;
            Description = request.Description;
        }
    }
}