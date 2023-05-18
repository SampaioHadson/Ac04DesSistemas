using DesSistemas.SnackNow.Api.Domain.Context;
using DesSistemas.SnackNow.Startup.ApiLayers.Database;
using Microsoft.EntityFrameworkCore;

namespace DesSistemas.SnackNow.Api.Domain.Repositories.Queries.UserSystem
{
    public class ExistsByUsernameQuery : QueryParamsBase<bool, SnackNowApiContext>
    {
        private readonly string _username;
        public ExistsByUsernameQuery(string username, bool useNewContext) : base(useNewContext)
        {
            _username = username;
        }

        public override Task<bool> Filter(SnackNowApiContext dbContext)
        {
            return dbContext.Users.AnyAsync(a => a.UserName == _username && a.IsActive);
        }
    }
}
