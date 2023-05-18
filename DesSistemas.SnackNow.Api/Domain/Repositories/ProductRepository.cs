using DesSistemas.SnackNow.Api.Domain.Context;
using DesSistemas.SnackNow.Api.Domain.Entities;
using DesSistemas.SnackNow.Api.Domain.Repositories.Interfaces;
using DesSistemas.SnackNow.Api.Domain.Repositories.Queries.Products;
using DesSistemas.SnackNow.Startup.ApiLayers.Database;

namespace DesSistemas.SnackNow.Api.Domain.Repositories
{
    public class ProductRepository : RepositoryBase<Product, long, SnackNowApiContext>, IProductRepository
    {
        public ProductRepository(SnackNowApiContext context) : base(context)
        {
        }

        public async Task<PaginationResponseBase<Product>> GetAllAsync(QueryPaginationRequest pagination, QueryFilterBase filter)
        {
            var query = new GetAllProductsQuery(pagination, filter, false);
            return await query.FilterAsync(_context);
        }
    }
}