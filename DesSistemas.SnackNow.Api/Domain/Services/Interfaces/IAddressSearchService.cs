using DesSistemas.SnackNow.Api.Domain.Entities;

namespace DesSistemas.SnackNow.Api.Domain.Services.Interfaces
{
    public interface IAddressSearchService
    {
        Task<Address> GetByPostalCodeAsync(string postalCode);
    }
}