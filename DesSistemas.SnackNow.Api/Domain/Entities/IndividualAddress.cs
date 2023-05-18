using DesSistemas.SnackNow.Startup.ApiLayers.Database;

namespace DesSistemas.SnackNow.Api.Domain.Entities
{
    public class IndividualAddress : EntityBase<long>
    {
        public string Number { get; set; } = null!;
        public string Complement { get; set; } = null!;
        public Address? Address { get; set; }
        public long AddressId { get; set; }

        public IndividualAddress(string number, string complement, long addressId)
        {
            Number = number;
            Complement = complement;
            AddressId = addressId;
        }
    }
}