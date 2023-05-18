using DesSistemas.SnackNow.Api.Dto.UserSystem;
using DesSistemas.SnackNow.Api.Integrations.AuthZero.Dto;
using DesSistemas.SnackNow.Startup.Configuration;
using DesSistemas.SnackNow.Startup.Exceptions;
using DesSistemas.SnackNow.Startup.Guard;
using DesSistemas.SnackNow.Startup.HttpIntegration.Base;
using DesSistemas.SnackNow.Startup.HttpIntegration.Builder;
using DesSistemas.SnackNow.Startup.HttpIntegration.Dto;

namespace DesSistemas.SnackNow.Api.Integrations.AuthZero
{
    public class AuthZeroSignUpEndpoint : HttpEndpointExecuteBase<AuthZeroSignUpResponse>
    {
        private readonly AuthZeroSignUpRequest _request;
        private readonly string _route;

        private const string FaultMessage = "Erro ao realizar cadastro de usuário.";

        public AuthZeroSignUpEndpoint(UserSystemAddRequest appRequest, AuthZeroConfig config)
        {
            _request = BindRequest(appRequest, config);
            _route = $"{config.UrlBase}/dbconnections/signup";
        }

        protected override HttpMessageRequestDto BuildRequest()
        {
            return new HttpMessageRequestBuilder()
                .WithUrl(_route)
                .Post()
                .WithJsonBody(_request)
                .Build();
        }

        protected override void Validate(HttpMessageResponseDto<AuthZeroSignUpResponse> response)
        {
            Guard.False(response.IsSuccess, () => new HttpInternalServerErrorException(FaultMessage));
            Guard.Null(response.Content, () => new HttpInternalServerErrorException(FaultMessage));
        }

        private static AuthZeroSignUpRequest BindRequest(UserSystemAddRequest appRequest, AuthZeroConfig config)
        {
            return new AuthZeroSignUpRequest
            {
                ClientId = config.ClientId,
                Connection = config.ClientConnection,
                Password = appRequest.Password,
                Username = appRequest.Username,
                Email = appRequest.Email,
                FamilyName = appRequest.FamilyName,
                GivenName = appRequest.GivenName,
                Name = appRequest.Name,
                Nickname = appRequest.Nickname
            };
        }
    }
}