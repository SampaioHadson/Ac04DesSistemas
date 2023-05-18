using Microsoft.EntityFrameworkCore;

namespace DesSistemas.SnackNow.Startup.ApiLayers.Database
{
    public abstract class QueryParamsBase<TResult, TContext>
        where TContext : DbContext
    {
        public bool UseNewContext { get; }

        protected QueryParamsBase(bool useNewContext)
        {
            UseNewContext = useNewContext;
        }

        public abstract Task<TResult> Filter(TContext dbContext);
    }

    public abstract class QueryParamsListBase<TResult, TContext>
        where TContext : DbContext
    {
        public bool UseNewContext { get; }

        protected QueryParamsListBase(bool useNewContext)
        {
            UseNewContext = useNewContext;
        }

        public abstract Task<List<TResult>> Filter(TContext dbContext);
    }
}