using DesSistemas.SnackNow.Api.Dto.UserSystem;
using DesSistemas.SnackNow.Api.Integrations.AuthZero.Dto;

namespace DesSistemas.SnackNow.Api.Integrations.AuthZero.Interfaces
{
    public interface IAuthZeroIntegration
    {
        Task<AuthZeroSignUpResponse> SignUpAsync(UserSystemAddRequest request);
        Task<AuthZeroLoginResponse> LoginAsync(AuthZeroLoginRequest request);
        Task ChangePasswordAsync(AuthZeroChangePassInternalRequest request);
    }
}