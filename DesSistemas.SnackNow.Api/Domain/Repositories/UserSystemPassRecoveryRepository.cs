using DesSistemas.SnackNow.Api.Domain.Context;
using DesSistemas.SnackNow.Api.Domain.Entities;
using DesSistemas.SnackNow.Api.Domain.Repositories.Interfaces;
using DesSistemas.SnackNow.Api.Domain.Repositories.Queries.UserSystemPassRecovery;
using DesSistemas.SnackNow.Startup.ApiLayers.Database;

namespace DesSistemas.SnackNow.Api.Domain.Repositories
{
    public class UserSystemPassRecoveryRepository : RepositoryBase<UserSystemPassRecovery, long, SnackNowApiContext>, IUserSystemPassRecoveryRepository
    {
        public UserSystemPassRecoveryRepository(SnackNowApiContext context) : base(context)
        {
        }

        public async Task<UserSystemPassRecovery?> GetByCodeAsync(string code)
        {
            var parameters = new GetByRandomCodeQuery(false, code);
            return await ExecuteAsync(parameters);
        }

        public async Task<UserSystemPassRecovery?> GetByRandomCodeAndVerifyCodeAsync(string code, string verifyCode)
        {
            var parameters = new GetByRandomCodeAndVerificationCodeQuery(false, code, verifyCode);
            return await ExecuteAsync(parameters);
        }
    }
}