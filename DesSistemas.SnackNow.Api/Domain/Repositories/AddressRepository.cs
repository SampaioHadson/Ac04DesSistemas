using DesSistemas.SnackNow.Api.Domain.Context;
using DesSistemas.SnackNow.Api.Domain.Entities;
using DesSistemas.SnackNow.Api.Domain.Repositories.Interfaces;
using DesSistemas.SnackNow.Api.Domain.Repositories.Queries.Addresses;
using DesSistemas.SnackNow.Startup.ApiLayers.Database;

namespace DesSistemas.SnackNow.Api.Domain.Repositories
{
    public class AddressRepository : RepositoryBase<Address, long, SnackNowApiContext>, IAddressRepository
    {
        public AddressRepository(SnackNowApiContext context) : base(context)
        {
        }

        public async Task<Address?> GetByPostalCodeAsync(string postalCode)
        {
            var parameters = new GetByPostalCodeQuery(false, postalCode);
            return await ExecuteAsync(parameters);
        }
    }
}