using Microsoft.EntityFrameworkCore;

namespace DesSistemas.SnackNow.Startup.ApiLayers.Database
{
    public abstract class RepositoryBase<TEntity, TId, TContext>
        where TEntity : EntityBase<TId>
        where TId : struct
        where TContext : DbContext, new()
    {
        protected readonly TContext _context;

        public RepositoryBase(TContext context)
        {
            _context = context;
        }

        public async Task<TEntity?> GetByIdAsync(TId id, bool active = true, bool tracking = false)
        {
            return await GetQuery(active, tracking).FirstOrDefaultAsync(f => f.Id.Equals(id));
        }

        public async Task<TId> AddAsync(TEntity entity)
        {
            await _context.AddAsync(entity);
            await SaveChangesAsync();
            return entity.Id;
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            entity.UpdatedAt = DateTime.Now;
            entity.IsActive = false;
            await UpdateAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _context.AddRangeAsync(entities);
            await SaveChangesAsync();
        }

        public async Task AddWithoutSaveAsync(TEntity entity)
        {
            await _context.AddAsync(entity);
        }

        public void UpdateWithoutSave(TEntity entity)
        {
            _context.Update(entity);
        }

        public void DeleteWithoutSave(TEntity entity)
        {
            entity.UpdatedAt = DateTime.Now;
            entity.IsActive = false;
            UpdateWithoutSave(entity);
        }

        public virtual async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        protected virtual async Task<TResult> ExecuteAsync<TResult>(QueryParamsBase<TResult, TContext> queryParams)
        {
            if (queryParams.UseNewContext)
            {
                using var context = new TContext();
                return await queryParams.Filter(context);
            }
            else
            {
                return await queryParams.Filter(_context);
            }
        }

        protected virtual async Task<List<TResult>> ExecuteAsync<TResult>(QueryParamsListBase<TResult, TContext> queryParams)
        {
            if (queryParams.UseNewContext)
            {
                using var context = new TContext();
                return await queryParams.Filter(context);
            }
            else
            {
                return await queryParams.Filter(_context);
            }
        }

        protected virtual IQueryable<TEntity> GetQuery(bool active = true, bool tracking = false)
        {
            var query = _context.Set<TEntity>().Where(w => w.IsActive == active);

            if (!tracking)
                query = query.AsNoTracking();

            return query;
        }
    }
}