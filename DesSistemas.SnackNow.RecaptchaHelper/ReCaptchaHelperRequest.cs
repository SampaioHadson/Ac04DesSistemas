using DesSistemas.SnackNow.Startup.HttpIntegration.Base;
using DesSistemas.SnackNow.Startup.HttpIntegration.Builder;
using DesSistemas.SnackNow.Startup.HttpIntegration.Dto;

namespace DesSistemas.SnackNow.RecaptchaHelper
{
    public class ReCaptchaHelperRequest : HttpEndpointExecuteBase<ReCaptchaResponse>
    {
        private readonly string _value;
        private readonly ReCaptchaConfig _config;

        public ReCaptchaHelperRequest(string value,
            ReCaptchaConfig config)
        {
            _value = value;
            _config = config;
        }

        protected override HttpMessageRequestDto BuildRequest()
        {
            return new HttpMessageRequestBuilder()
                .Post()
                .WithUrl(_config.Url)
                .WithParam("response", _value)
                .WithParam("secret", _config.Secret)
                .Build();
        }
    }
}