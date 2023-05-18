using DesSistemas.SnackNow.Startup.HttpIntegration.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesSistemas.SnackNow.RecaptchaHelper
{
    public class GeocodingHelper : IGeocodingHelper
    {
        private readonly ReCaptchaConfig _captchaConfig;
        private readonly IHttpMessageRequestService _requestHelper;

        public GeocodingHelper(ReCaptchaConfig captchaConfig,
            IHttpMessageRequestService requestHelper)
        {
            _captchaConfig = captchaConfig;
            _requestHelper = requestHelper;
        }

        public async Task<string?> GetAddressAsync(string latitude, string longitude)
        {
            var request = new GeoCodingRequest(latitude, longitude, _captchaConfig);
            var result = await request.Execute(_requestHelper);
            return result.Results.FirstOrDefault()?.FormattedAddress;
        }
    }
}
