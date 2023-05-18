using DesSistemas.SnackNow.Api.Domain.Context;
using DesSistemas.SnackNow.Startup.ApiLayers.Database;
using Microsoft.EntityFrameworkCore;

namespace DesSistemas.SnackNow.Api.Domain.Repositories.Queries.UserSystems
{
    public class GetByEmailQuery : QueryParamsBase<Entities.UserSystem?, SnackNowApiContext>
    {
        private readonly string _email;
        public GetByEmailQuery(bool useNewContext, string email) : base(useNewContext)
        {
            _email = email;
        }

        public override async Task<Entities.UserSystem?> Filter(SnackNowApiContext dbContext)
        {
            return await dbContext
                .Set<Entities.UserSystem>()
                .FirstOrDefaultAsync(f => f.Email.ToLower() == _email.ToLower());
        }
    }
}