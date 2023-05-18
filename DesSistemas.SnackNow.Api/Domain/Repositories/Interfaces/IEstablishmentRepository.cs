using DesSistemas.SnackNow.Api.Domain.Entities;
using DesSistemas.SnackNow.Startup.ApiLayers.Database;

namespace DesSistemas.SnackNow.Api.Domain.Repositories.Interfaces
{
    public interface IEstablishmentRepository : IRepositoryBase<Establishment, long>
    {
        Task<PaginationResponseBase<Establishment>> GetAllAsync(QueryPaginationRequest pagination, QueryFilterBase filter);
    }
}