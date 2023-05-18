using DesSistemas.SnackNow.Api.Domain.Context;
using DesSistemas.SnackNow.Api.Domain.Entities;
using DesSistemas.SnackNow.Startup.ApiLayers.Database;
using Microsoft.EntityFrameworkCore;

namespace DesSistemas.SnackNow.Api.Domain.Repositories.Queries.Addresses
{
    public class GetByPostalCodeQuery : QueryParamsBase<Address?, SnackNowApiContext>
    {
        private readonly string _postalCode;
        public GetByPostalCodeQuery(bool useNewContext, string postalCode) : base(useNewContext)
        {
            _postalCode = postalCode;
        }

        public override async Task<Address?> Filter(SnackNowApiContext dbContext)
        {
            return await dbContext.Addresses.FirstOrDefaultAsync(f => f.PostalCode == _postalCode && f.IsActive);
        }
    }
}
