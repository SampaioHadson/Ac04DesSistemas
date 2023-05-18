using DesSistemas.SnackNow.Api.Domain.Context;
using DesSistemas.SnackNow.Api.Domain.Entities;
using DesSistemas.SnackNow.Api.Domain.Repositories.Interfaces;
using DesSistemas.SnackNow.Api.Domain.Repositories.Queries.UserSystem;
using DesSistemas.SnackNow.Api.Domain.Repositories.Queries.UserSystems;
using DesSistemas.SnackNow.Startup.ApiLayers.Database;

namespace DesSistemas.SnackNow.Api.Domain.Repositories
{
    public class UserSystemRepository : RepositoryBase<UserSystem, long, SnackNowApiContext>, IUserSystemRepository
    {
        public UserSystemRepository(SnackNowApiContext context) : base(context)
        {
        }

        public async Task<bool> AnyWithUsernameAsync(string username)
        {
            var parameters = new ExistsByUsernameQuery(username, false);
            return await ExecuteAsync(parameters);
        }

        public async Task<UserSystem?> GetByEmailAsync(string email)
        {
            var parameters = new GetByEmailQuery(false, email);
            return await ExecuteAsync(parameters);
        }
    }
}