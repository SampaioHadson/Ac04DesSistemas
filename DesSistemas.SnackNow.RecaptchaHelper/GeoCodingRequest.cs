using DesSistemas.SnackNow.Startup.HttpIntegration.Base;
using DesSistemas.SnackNow.Startup.HttpIntegration.Builder;
using DesSistemas.SnackNow.Startup.HttpIntegration.Dto;

namespace DesSistemas.SnackNow.RecaptchaHelper
{
    public class GeoCodingRequest : HttpEndpointExecuteBase<GeoCodingResponse>
    {
        private readonly string _latitute;
        private readonly string _longitude;
        private readonly ReCaptchaConfig _captchaConfig;

        public GeoCodingRequest(string latitute,
            string longitude,
            ReCaptchaConfig captchaConfig)
        {
            _latitute = latitute;
            _longitude = longitude;
            _captchaConfig = captchaConfig;
        }

        protected override HttpMessageRequestDto BuildRequest()
        {
            return new HttpMessageRequestBuilder()
                .Get()
                .WithUrl(_captchaConfig.GeocodingUrl)
                .WithParam("latlng", $"{_latitute},{_longitude}")
                .WithParam("key", _captchaConfig.Key)
                .Build();
        }
    }
}