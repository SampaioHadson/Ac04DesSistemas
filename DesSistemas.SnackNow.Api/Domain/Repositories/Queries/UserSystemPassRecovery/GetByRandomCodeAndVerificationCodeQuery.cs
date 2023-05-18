using DesSistemas.SnackNow.Api.Domain.Context;
using DesSistemas.SnackNow.Startup.ApiLayers.Database;
using Microsoft.EntityFrameworkCore;

namespace DesSistemas.SnackNow.Api.Domain.Repositories.Queries.UserSystemPassRecovery
{
    public class GetByRandomCodeAndVerificationCodeQuery : QueryParamsBase<Entities.UserSystemPassRecovery?, SnackNowApiContext>
    {
        private readonly string _code;
        private readonly string _verificationCode;

        public GetByRandomCodeAndVerificationCodeQuery(bool useNewContext,
            string code,
            string verificationCode) : base(useNewContext)
        {
            _code = code;
            _verificationCode = verificationCode;
        }

        public override async Task<Entities.UserSystemPassRecovery?> Filter(SnackNowApiContext dbContext)
        {
            return await dbContext.Set<Entities.UserSystemPassRecovery>()
                .FirstOrDefaultAsync(f => f.IsActive 
                    && f.MessageCode == _code
                    && f.CodeToVerify == _verificationCode);
        }
    }
}