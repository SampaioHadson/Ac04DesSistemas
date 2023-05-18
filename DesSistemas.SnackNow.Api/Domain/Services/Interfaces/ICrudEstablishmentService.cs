using DesSistemas.SnackNow.Api.Domain.Entities;
using DesSistemas.SnackNow.Api.Dto.Establishments;
using DesSistemas.SnackNow.Startup.ApiLayers.Database;

namespace DesSistemas.SnackNow.Api.Domain.Services.Interfaces
{
    public interface ICrudEstablishmentService
    {
        Task<long> AddAsync(EstablishmentAddRequest request);
        Task DeleteAsync(long id);
        Task<PaginationResponseBase<Establishment>> GetAllAsync(QueryPaginationRequest pagination, QueryFilterBase filter);
        Task<Establishment> GetByIdAsync(long id, bool active = true, bool tracking = false);
        Task UpdateAsync(EstablishmentAddRequest request, long id);
    }
}