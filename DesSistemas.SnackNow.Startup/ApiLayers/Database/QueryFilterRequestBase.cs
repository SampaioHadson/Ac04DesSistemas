using Microsoft.EntityFrameworkCore;

namespace DesSistemas.SnackNow.Startup.ApiLayers.Database
{
    public abstract class QueryFilterRequestBase<TContext, TFilter, TResult> 
        where TContext : DbContext
        where TFilter : class
    {
        public TFilter Filter { get; set; }
        public QueryPaginationRequest Pagination { get; set; }
        public bool UseNewContext { get; }

        protected QueryFilterRequestBase(QueryPaginationRequest pagination, TFilter filter, bool useNewContext)
        {
            UseNewContext = useNewContext;
            Pagination = pagination;
            Filter = filter;
            FormatPageValues();
        }

        public virtual async Task<PaginationResponseBase<TResult>> FilterAsync(TContext dbContext)
        {
            var query = FilterQuery(dbContext, Filter);
            var totalItems = await query.CountAsync();
            query = PaginateItems(query);
            
            var items = await query.ToListAsync();
            var totalPages = totalItems / Pagination.PageSize;

            return new PaginationResponseBase<TResult>(items,
                Pagination.Page,
                Pagination.PageSize,
                totalItems,
                GetTotalPages(totalItems, Pagination.PageSize));
        }

        protected virtual IQueryable<TResult> PaginateItems(IQueryable<TResult> query)
        {
            var skip = Pagination.Page * Pagination.PageSize;
            if (Pagination.Page == 1)
                skip = 0;

            return query.Skip(skip).Take(Pagination.PageSize);
        }

        protected abstract IQueryable<TResult> FilterQuery(TContext dbContext, TFilter filter);

        protected virtual void FormatPageValues()
        {
            if (Pagination.Page <= 0)
                Pagination.Page = 1;

            if (Pagination.PageSize <= 0)
                Pagination.PageSize = 10;
        }

        protected virtual int GetTotalPages(int totalItems, int perPage)
        {
            var incrementInPage = 0;
            if (totalItems % perPage != 0)
                incrementInPage++;

            var totalPage = totalItems / perPage + incrementInPage;
            if (totalPage <= 0)
                totalPage = 1;

            return totalPage;
        }
    }
}