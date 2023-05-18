using DesSistemas.SnackNow.Api.Domain.Entities;
using DesSistemas.SnackNow.Api.Dto.Product;
using DesSistemas.SnackNow.Startup.ApiLayers.Database;

namespace DesSistemas.SnackNow.Api.Domain.Services.Interfaces
{
    public interface ICrudProductService
    {
        Task<long> AddAsync(ProductAddRequest request);
        Task<Product> GetByIdAsync(long id, bool active = true, bool tracking = false);
        Task UpdateAsync(ProductAddRequest request, long id);
        Task DeleteAsync(long id);
        Task<PaginationResponseBase<Product>> GetAllAsync(QueryPaginationRequest pagination, QueryFilterBase filter);
    }
}