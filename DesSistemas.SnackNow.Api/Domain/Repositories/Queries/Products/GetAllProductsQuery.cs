using DesSistemas.SnackNow.Api.Domain.Context;
using DesSistemas.SnackNow.Api.Domain.Entities;
using DesSistemas.SnackNow.Startup.ApiLayers.Database;
using Microsoft.EntityFrameworkCore;

namespace DesSistemas.SnackNow.Api.Domain.Repositories.Queries.Products
{
    public class GetAllProductsQuery : QueryFilterRequestBase<SnackNowApiContext, QueryFilterBase, Product>
    {
        public GetAllProductsQuery(QueryPaginationRequest pagination, QueryFilterBase filter, bool useNewContext) : base(pagination, filter, useNewContext)
        {
        }

        protected override IQueryable<Product> FilterQuery(SnackNowApiContext dbContext, QueryFilterBase filter)
        {
            var query = dbContext.Products.AsNoTracking();

            if (filter is null) 
                return query;

            if (filter.IsActive.HasValue)
                query = query.Where(w => w.IsActive == filter.IsActive);

            if (filter.MaxCreatedAt.HasValue)
                query = query.Where(w => w.CreatedAt <= filter.MaxCreatedAt);

            if (filter.MinCreatedAt.HasValue)
                query = query.Where(w => w.CreatedAt >= filter.MinCreatedAt);

            return query;
        }
    }
}