using DesSistemas.SnackNow.Api.Domain.Entities;
using DesSistemas.SnackNow.Startup.ApiLayers.Database;

namespace DesSistemas.SnackNow.Api.Domain.Repositories.Interfaces
{
    public interface IUserSystemRepository : IRepositoryBase<UserSystem, long>
    {
        Task<bool> AnyWithUsernameAsync(string username);
        Task<UserSystem?> GetByEmailAsync(string email);
    }
}