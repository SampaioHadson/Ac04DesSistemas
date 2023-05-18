using DesSistemas.SnackNow.Startup.Configuration;
using DesSistemas.SnackNow.Startup.Exceptions;
using DesSistemas.SnackNow.Startup.Guard;
using DesSistemas.SnackNow.Startup.HttpIntegration.Base;
using DesSistemas.SnackNow.Startup.HttpIntegration.Builder;
using DesSistemas.SnackNow.Startup.HttpIntegration.Dto;
using DesSistemas.SnackNow.Twillo.Configuration;
using DesSistemas.SnackNow.Twillo.Integration.Dto;
using System.Text;

namespace DesSistemas.SnackNow.Twillo.Integration
{
    public class TwilloSendSmsEndpoint : HttpEndpointExecuteBase<SendSmsResponse>
    {
        private readonly Dictionary<string, string> _body;
        private readonly string _route;
        private readonly string _authToken;
        private const string FaultMessage = "Ocorreu um erro ao enviar SMS.";

        public TwilloSendSmsEndpoint(string to,
            string message,
            TwilloConfig config)
        {
            _body = new Dictionary<string, string>
            {
                {"To", to },
                {"Body", message },
                {"MessagingServiceSid", config.MessagingServiceSid}
            };
            _route = $"{config.UrlBase}/2010-04-01/Accounts/{config.Token}/Messages.json";
            _authToken = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{config.Token}:{config.Secrect}"));
        }

        protected override void Validate(HttpMessageResponseDto<SendSmsResponse> response)
        {
            Guard.False(response.IsSuccess, () => new HttpInternalServerErrorException(FaultMessage));
        }

        protected override HttpMessageRequestDto BuildRequest()
        {
            return new HttpMessageRequestBuilder()
                .Post()
                .WithFormUrlEncodedContent(_body)
                .WithHeader("Authorization", $"Basic {_authToken}")
                .WithUrl(_route)
                .Build();
        }
    }
}