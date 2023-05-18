using DesSistemas.SnackNow.Api.Integrations.AuthZero.Dto;

namespace DesSistemas.SnackNow.Api.Domain.Services.Interfaces
{
    public interface IAuthService
    {
        Task<AuthZeroLoginResponse> LoginAsync(AuthZeroLoginRequest login);
    }
}