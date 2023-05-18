using DesSistemas.SnackNow.Startup.HttpIntegration.Services.Interfaces;

namespace DesSistemas.SnackNow.RecaptchaHelper
{
    public class RecaptchaHelper : IRecaptchaHelper
    {
        private readonly ReCaptchaConfig _config;
        private readonly IHttpMessageRequestService _requestHelper;

        public RecaptchaHelper(ReCaptchaConfig config,
            IHttpMessageRequestService requestHelper)
        {
            _config = config;
            _requestHelper = requestHelper;
        }

        public async Task<bool> ValidateAsync(string value)
        {
            try
            {
                var request = new ReCaptchaHelperRequest(value, _config);
                var result = await request.Execute(_requestHelper);
                return result.Success;
            }
            catch
            {
                return false;
            }
        }
    }

    public interface IRecaptchaHelper
    {
        Task<bool> ValidateAsync(string value);
    }
}