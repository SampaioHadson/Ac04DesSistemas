using DesSistemas.SnackNow.Api.Dto.UserSystem;
using DesSistemas.SnackNow.Api.Integrations.AuthZero.Dto;
using DesSistemas.SnackNow.Api.Integrations.AuthZero.Interfaces;
using DesSistemas.SnackNow.Startup.Configuration.Interfaces;
using DesSistemas.SnackNow.Startup.HttpIntegration.Services.Interfaces;

namespace DesSistemas.SnackNow.Api.Integrations.AuthZero
{
    public class AuthZeroIntegration : IAuthZeroIntegration
    {
        private readonly IHttpMessageRequestService _httpService;
        private readonly IAppEnvironments _env;
        private DateTime? LastSystemLogin { get; set; }
        private string? SystemToken { get; set; }

        public AuthZeroIntegration(IHttpMessageRequestService httpService, IAppEnvironments env)
        {
            _httpService = httpService;
            _env = env;
        }

        public async Task<AuthZeroSignUpResponse> SignUpAsync(UserSystemAddRequest request)
        {
            var requestExecutor = new AuthZeroSignUpEndpoint(request, _env.AuthZero);
            return await requestExecutor.Execute(_httpService);
        }
        
        public async Task<AuthZeroLoginResponse> LoginAsync(AuthZeroLoginRequest request)
        {
            var requestExecutor = new AuthZeroLoginEndpoint(_env.AuthZero, request);
            return await requestExecutor.Execute(_httpService);
        }

        public async Task ChangePasswordAsync(AuthZeroChangePassInternalRequest request)
        {
            await CheckLoginAsync();
            var requestExecutor = new AuthZeroChangePasswordEndpoint(_env.AuthZero, SystemToken!, request);
            await requestExecutor.Execute(_httpService);
        }

        private async Task CheckLoginAsync()
        {
            if (LastSystemLogin == null || LastSystemLogin <= DateTime.Now)
            {
                var requestExecutor = new AuthZeroSystemLoginEndpoint(_env.AuthZero);
                var login = await requestExecutor.Execute(_httpService);
                SystemToken = login.AccessToken;
            }
        }
    }
}