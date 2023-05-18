using DesSistemas.SnackNow.Api.Integrations.AuthZero.Dto;
using DesSistemas.SnackNow.Startup.Configuration;
using DesSistemas.SnackNow.Startup.Exceptions;
using DesSistemas.SnackNow.Startup.Guard;
using DesSistemas.SnackNow.Startup.HttpIntegration.Base;
using DesSistemas.SnackNow.Startup.HttpIntegration.Builder;
using DesSistemas.SnackNow.Startup.HttpIntegration.Dto;

namespace DesSistemas.SnackNow.Api.Integrations.AuthZero
{
    public class AuthZeroChangePasswordEndpoint : HttpEndpointExecuteBase<object>
    {
        private readonly string _route;
        private readonly string _token;
        private readonly AuthZeroChangePassRequest _body;

        private const string FaultMessage = "Erro ao realizar login.";

        public AuthZeroChangePasswordEndpoint(AuthZeroConfig config, string systemToken, AuthZeroChangePassInternalRequest request)
        {
            _route = $"{config.UrlBase}/api/v2/users/auth0|{request.AuthZeroId}";
            _body = new AuthZeroChangePassRequest(request.NewPassword, config.ClientConnection);
            _token = $"Bearer {systemToken}";
        }

        protected override void Validate(HttpMessageResponseDto<object> response)
        {
            Guard.False(response.IsSuccess, () => new HttpInternalServerErrorException(FaultMessage));
            Guard.Null(response.Content, () => new HttpInternalServerErrorException(FaultMessage));
        }

        protected override HttpMessageRequestDto BuildRequest()
        {
            return new HttpMessageRequestBuilder()
                .Patch()
                .WithUrl(_route)
                .WithJsonBody(_body)
                .WithHeader("Authorization", _token)
                .Build();
        }
    }
}