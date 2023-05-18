using DesSistemas.SnackNow.Api.Dto.UserSystemPassRecovery;

namespace DesSistemas.SnackNow.Api.Domain.Services.Interfaces
{
    public interface IPassRecoveryService
    {
        Task ChangePasswordAsync(ChangePasswordRequest change);
        Task<string> ConfirmSmsAsync(ConfirmSmsRequest confirm);
        Task SendSmsToRecoveryAsync(string email);
    }
}