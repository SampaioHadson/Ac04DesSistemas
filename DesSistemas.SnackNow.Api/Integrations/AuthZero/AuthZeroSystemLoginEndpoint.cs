using DesSistemas.SnackNow.Api.Integrations.AuthZero.Dto;
using DesSistemas.SnackNow.Startup.Configuration;
using DesSistemas.SnackNow.Startup.Exceptions;
using DesSistemas.SnackNow.Startup.Guard;
using DesSistemas.SnackNow.Startup.HttpIntegration.Base;
using DesSistemas.SnackNow.Startup.HttpIntegration.Builder;
using DesSistemas.SnackNow.Startup.HttpIntegration.Dto;

namespace DesSistemas.SnackNow.Api.Integrations.AuthZero
{
    public class AuthZeroSystemLoginEndpoint : HttpEndpointExecuteBase<AuthZeroLoginResponse>
    {
        private const string FaultMessage = "Erro ao realizar login.";
        private readonly Dictionary<string, string> _body;
        private readonly string _route;

        public AuthZeroSystemLoginEndpoint(AuthZeroConfig config)
        {
            _route = $"{config.UrlBase}/oauth/token";
            _body = new Dictionary<string, string>
            {
                { "grant_type", "client_credentials" },
                { "audience", config.Audience },
                { "client_id", config.ClientId },
                { "client_secret", config.ClientSecret },
            };
        }

        protected override HttpMessageRequestDto BuildRequest()
        {
            return new HttpMessageRequestBuilder()
                .Post()
                .WithUrl(_route)
                .WithFormUrlEncodedContent(_body)
                .Build();
        }

        protected override void Validate(HttpMessageResponseDto<AuthZeroLoginResponse> response)
        {
            Guard.False(response.IsSuccess, () => new HttpInternalServerErrorException(FaultMessage));
            Guard.Null(response.Content, () => new HttpInternalServerErrorException(FaultMessage));
        }
    }
}