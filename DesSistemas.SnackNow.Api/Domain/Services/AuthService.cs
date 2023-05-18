using DesSistemas.SnackNow.Api.Domain.Services.Interfaces;
using DesSistemas.SnackNow.Api.Integrations.AuthZero.Dto;
using DesSistemas.SnackNow.Api.Integrations.AuthZero.Interfaces;
using DesSistemas.SnackNow.Startup.Exceptions;
using DesSistemas.SnackNow.Startup.Guard;

namespace DesSistemas.SnackNow.Api.Domain.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthZeroIntegration _authZeroIntegration;

        public AuthService(IAuthZeroIntegration authZeroIntegration)
        {
            _authZeroIntegration = authZeroIntegration;
        }

        public async Task<AuthZeroLoginResponse> LoginAsync(AuthZeroLoginRequest login)
        {
            Guard.NullOrEmpty(login.Username, () => new HttpBadRequestException("O campo Username é obrigatório"));
            Guard.NullOrEmpty(login.Password, () => new HttpBadRequestException("O campo Password é obrigatório"));

            return await _authZeroIntegration.LoginAsync(login);
        }
    }
}