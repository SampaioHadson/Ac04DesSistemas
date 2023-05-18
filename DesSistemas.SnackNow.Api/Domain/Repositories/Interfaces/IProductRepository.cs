using DesSistemas.SnackNow.Api.Domain.Entities;
using DesSistemas.SnackNow.Startup.ApiLayers.Database;

namespace DesSistemas.SnackNow.Api.Domain.Repositories.Interfaces
{
    public interface IProductRepository : IRepositoryBase<Product, long>
    {
        Task<PaginationResponseBase<Product>> GetAllAsync(QueryPaginationRequest pagination, QueryFilterBase filter);
    }
}