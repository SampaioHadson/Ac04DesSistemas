using DesSistemas.SnackNow.Api.Domain.Context;
using DesSistemas.SnackNow.Api.Domain.Entities;
using DesSistemas.SnackNow.Api.Domain.Repositories.Interfaces;
using DesSistemas.SnackNow.Startup.ApiLayers.Database;
using Microsoft.EntityFrameworkCore;

namespace DesSistemas.SnackNow.Api.Domain.Repositories
{
    public class BarRepository : RepositoryBase<BarEntity, long, SnackNowApiContext>, IBarRepository
    {
        public BarRepository(SnackNowApiContext context) : base(context)
        {
        }

        public async Task<List<BarEntity>> GetAll()
        {
            return await _context.BarEntities.ToListAsync();
        }
    }
}
