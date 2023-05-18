using DesSistemas.SnackNow.MessengerApi.Integration;
using DesSistemas.SnackNow.MessengerApi.Integration.Interfaces;
using DesSistemas.SnackNow.MessengerApi.Runner;
using DesSistemas.SnackNow.MessengerApi.Runner.Handlers;
using Microsoft.Extensions.DependencyInjection;

namespace DesSistemas.SnackNow.MessengerApi.Configuration
{
    public static class DependencyInjection
    {
        public static void AddMessengerClient(this IServiceCollection services, Action<MessengerApiConfig> cfgAction)
        {
            var cfg = new MessengerApiConfig();
            cfgAction.Invoke(cfg);
            services.AddSingleton(cfg);

            if (cfg.ImplementationType is null) 
            {
                services.AddTransient(typeof(IMessengerHandler), typeof(DefaultMessengerChatHandler));
            }
            else
            {
                services.AddTransient(typeof(IMessengerHandler), cfg.ImplementationType);
            }

            services.AddSingleton<IMessengerIntegration, MessengerIntegration>();
            services.AddHostedService<MessengerChatRunner>();
        }
    }
}