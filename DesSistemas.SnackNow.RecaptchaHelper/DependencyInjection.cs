using Microsoft.Extensions.DependencyInjection;

namespace DesSistemas.SnackNow.RecaptchaHelper
{
    public static class DependencyInjection
    {
        public static void AddReCaptcha(this IServiceCollection servics, ReCaptchaConfig config)
        {
            servics.AddSingleton(config);

            servics.AddTransient<IRecaptchaHelper, RecaptchaHelper>();
            servics.AddTransient<IGeocodingHelper, GeocodingHelper>();
        }
    }
}