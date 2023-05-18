using DesSistemas.SnackNow.Api.Domain.Entities;
using DesSistemas.SnackNow.Startup.ApiLayers.Database;

namespace DesSistemas.SnackNow.Api.Domain.Repositories.Interfaces
{
    public interface IBarRepository : IRepositoryBase<BarEntity, long>
    {
        Task<List<BarEntity>> GetAll();
    }
}
