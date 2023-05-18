using DesSistemas.SnackNow.Startup.Configuration.Interfaces;
using DesSistemas.SnackNow.Startup.HttpIntegration.Services.Interfaces;
using DesSistemas.SnackNow.Twillo.Configuration;
using DesSistemas.SnackNow.Twillo.Integration.Interfaces;

namespace DesSistemas.SnackNow.Twillo.Integration
{
    public class TwilloIntegration : ITwilloIntegration
    {
        private readonly IHttpMessageRequestService _httpService;
        private readonly TwilloConfig _env;

        public TwilloIntegration(IHttpMessageRequestService httpService, TwilloConfig env)
        {
            _httpService = httpService;
            _env = env;
        }

        public async Task SendSmsAsync(string to, string message)
        {
            var requestExecutor = new TwilloSendSmsEndpoint(to, message, _env);
            await requestExecutor.Execute(_httpService);
        }
    }
}