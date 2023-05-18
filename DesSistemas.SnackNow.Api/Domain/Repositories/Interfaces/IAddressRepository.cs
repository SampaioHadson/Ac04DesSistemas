using DesSistemas.SnackNow.Api.Domain.Entities;
using DesSistemas.SnackNow.Startup.ApiLayers.Database;

namespace DesSistemas.SnackNow.Api.Domain.Repositories.Interfaces
{
    public interface IAddressRepository : IRepositoryBase<Address, long>
    {
        Task<Address?> GetByPostalCodeAsync(string postalCode);
    }
}