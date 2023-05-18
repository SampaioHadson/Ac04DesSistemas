using DesSistemas.SnackNow.Api.Domain.Entities;
using DesSistemas.SnackNow.Startup.ApiLayers.Database;

namespace DesSistemas.SnackNow.Api.Domain.Repositories.Interfaces
{
    public interface IMessengerMessageRepository : IRepositoryBase<MessengerMessage, long>
    {
        Task<bool> HasAnyWithId(string id);
    }
}