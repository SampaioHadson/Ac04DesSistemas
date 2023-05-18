using DesSistemas.SnackNow.Api.Domain.Context;
using DesSistemas.SnackNow.Startup.ApiLayers.Database;
using Microsoft.EntityFrameworkCore;

namespace DesSistemas.SnackNow.Api.Domain.Repositories.Queries.UserSystemPassRecovery
{
    public class GetByRandomCodeQuery : QueryParamsBase<Entities.UserSystemPassRecovery?, SnackNowApiContext>
    {
        private readonly string _code;

        public GetByRandomCodeQuery(bool useNewContext, string code) : base(useNewContext)
        {
            _code = code;
        }

        public override async Task<Entities.UserSystemPassRecovery?> Filter(SnackNowApiContext dbContext)
        {
            return await dbContext.Set<Entities.UserSystemPassRecovery>()
                .FirstOrDefaultAsync(f => f.IsActive && f.MessageCode == _code);
        }
    }
}