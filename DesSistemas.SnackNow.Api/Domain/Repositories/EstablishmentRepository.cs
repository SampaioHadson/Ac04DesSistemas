using DesSistemas.SnackNow.Api.Domain.Context;
using DesSistemas.SnackNow.Api.Domain.Entities;
using DesSistemas.SnackNow.Api.Domain.Repositories.Interfaces;
using DesSistemas.SnackNow.Api.Domain.Repositories.Queries.Establishments;
using DesSistemas.SnackNow.Startup.ApiLayers.Database;

namespace DesSistemas.SnackNow.Api.Domain.Repositories
{
    public class EstablishmentRepository : RepositoryBase<Establishment, long, SnackNowApiContext>, IEstablishmentRepository
    {
        public EstablishmentRepository(SnackNowApiContext context) : base(context)
        {
        }

        public async Task<PaginationResponseBase<Establishment>> GetAllAsync(QueryPaginationRequest pagination, QueryFilterBase filter)
        {
            var query = new GetAllEstablishmentsQuery(pagination, filter, false);
            return await query.FilterAsync(_context);
        }
    }
}