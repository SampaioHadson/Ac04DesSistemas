using DesSistemas.SnackNow.Api.Domain.Context;
using DesSistemas.SnackNow.Api.Domain.Entities;
using DesSistemas.SnackNow.Startup.ApiLayers.Database;
using Microsoft.EntityFrameworkCore;

namespace DesSistemas.SnackNow.Api.Domain.Repositories.Queries.Establishments
{
    public class GetAllEstablishmentsQuery : QueryFilterRequestBase<SnackNowApiContext, QueryFilterBase, Establishment>
    {
        public GetAllEstablishmentsQuery(QueryPaginationRequest pagination, QueryFilterBase filter, bool useNewContext) : base(pagination, filter, useNewContext)
        {
        }

        protected override IQueryable<Establishment> FilterQuery(SnackNowApiContext dbContext, QueryFilterBase filter)
        {
            var query = dbContext.Establishments.AsNoTracking();

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