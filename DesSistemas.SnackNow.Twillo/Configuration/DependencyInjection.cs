using DesSistemas.SnackNow.Twillo.Integration;
using DesSistemas.SnackNow.Twillo.Integration.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DesSistemas.SnackNow.Twillo.Configuration
{
    public static class DependencyInjection
    {
        public static void AddTwillo(this IServiceCollection services, TwilloConfig config)
        {
            services.AddSingleton(config);
            services.AddTransient<ITwilloIntegration, TwilloIntegration>();
        }
    }
}