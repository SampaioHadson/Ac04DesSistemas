using AutoMapper;
using DesSistemas.SnackNow.Startup.Configuration.Interfaces;
using DesSistemas.SnackNow.Startup.HttpIntegration.Services;
using DesSistemas.SnackNow.Startup.HttpIntegration.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DesSistemas.SnackNow.Startup.Configuration
{
    public static class StartupDependencyInjection
    {
        public static void AddStartupDependency(this IServiceCollection services)
        {
            services.AddSingleton<IHttpMessageRequestService, HttpMessageRequestService>();

            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddMaps(assemblies);
            });
            services.AddSingleton(configuration.CreateMapper());

            var env = new AppEnvironments
            {
                ViaCepUrlBase = "https://viacep.com.br/ws/{0}/json/",
                AuthZero = new AuthZeroConfig
                {
                    Audience = "",
                    ClientId = "",
                    ClientSecret = "",
                    UrlBase = "",
                    ClientConnection = "",
                }
            };
            services.AddSingleton<IAppEnvironments>(env);
        }
    }
}