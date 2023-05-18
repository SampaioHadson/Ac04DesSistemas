using DesSistemas.SnackNow.Api.Integrations.ViaCep.Dto;
using DesSistemas.SnackNow.Startup.ApiLayers.Database;

namespace DesSistemas.SnackNow.Api.Domain.Entities
{
    public class Address : EntityBase<long>
    {
        public string City { get; set; } = null!;
        public string Street { get; set; } = null!;
        public string PostalCode { get; set; } = null!;
        public string State { get; set; } = null!;
        public string Neighborhood { get; set; } = null!;

        public Address() { }

        public Address(string city, string street, string postalCode, string state, string neighborhood)
        {
            City = city;
            Street = street;
            PostalCode = postalCode;
            State = state;
            Neighborhood = neighborhood;
        }

        public Address(ViaCepResponse viaCepResponse, string postalCode)
        {
            City = viaCepResponse.City!;
            Street = viaCepResponse.Street!;
            State = viaCepResponse.State!;
            Neighborhood = viaCepResponse.Neighborhood!;
            PostalCode = postalCode;
        }
    }
}