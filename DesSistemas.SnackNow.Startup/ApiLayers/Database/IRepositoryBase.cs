namespace DesSistemas.SnackNow.Startup.ApiLayers.Database
{
    public interface IRepositoryBase<TEntity, TId>
        where TEntity : EntityBase<TId>
        where TId : struct
    {
        Task<TId> AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        Task AddWithoutSaveAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        void DeleteWithoutSave(TEntity entity);
        Task<TEntity?> GetByIdAsync(TId id, bool active = true, bool tracking = false);
        Task SaveChangesAsync();
        Task UpdateAsync(TEntity entity);
        void UpdateWithoutSave(TEntity entity);
    }
}