using DesSistemas.SnackNow.Api.Domain.Entities;
using DesSistemas.SnackNow.Startup.ApiLayers.Database;

namespace DesSistemas.SnackNow.Api.Domain.Repositories.Interfaces
{
    public interface IUserSystemPassRecoveryRepository : IRepositoryBase<UserSystemPassRecovery, long>
    {
        Task<UserSystemPassRecovery?> GetByRandomCodeAndVerifyCodeAsync(string code, string verifyCode);
        Task<UserSystemPassRecovery?> GetByCodeAsync(string code);
    }
}