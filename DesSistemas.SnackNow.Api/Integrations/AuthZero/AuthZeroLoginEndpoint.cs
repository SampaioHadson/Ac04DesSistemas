using DesSistemas.SnackNow.Api.Integrations.AuthZero.Dto;
using DesSistemas.SnackNow.Startup.Configuration;
using DesSistemas.SnackNow.Startup.Exceptions;
using DesSistemas.SnackNow.Startup.Guard;
using DesSistemas.SnackNow.Startup.HttpIntegration.Base;
using DesSistemas.SnackNow.Startup.HttpIntegration.Builder;
using DesSistemas.SnackNow.Startup.HttpIntegration.Dto;

namespace DesSistemas.SnackNow.Api.Integrations.AuthZero
{
    public class AuthZeroLoginEndpoint : HttpEndpointExecuteBase<AuthZeroLoginResponse>
    {
        private readonly string _route;
        private readonly Dictionary<string, string> _body;

        private const string FaultMessage = "Erro ao realizar login.";

        public AuthZeroLoginEndpoint(AuthZeroConfig config, AuthZeroLoginRequest request)
        {
            _route = $"{config.UrlBase}/oauth/token";
            _body = new Dictionary<string, string>
            {
                { "grant_type", "password" },
                { "username",  request.Username},
                { "password", request.Password },
                { "audience", config.Audience },
                { "client_id", config.ClientId },
                { "client_secret", config.ClientSecret },
            };
        }

        protected override void Validate(HttpMessageResponseDto<AuthZeroLoginResponse> response)
        {
            Guard.False(response.IsSuccess, () => new HttpInternalServerErrorException(FaultMessage));
            Guard.Null(response.Content, () => new HttpInternalServerErrorException(FaultMessage));
        }

        protected override HttpMessageRequestDto BuildRequest()
        {
            return new HttpMessageRequestBuilder()
                .Post()
                .WithUrl(_route)
                .WithFormUrlEncodedContent(_body)
                .Build();
        }
    }
}