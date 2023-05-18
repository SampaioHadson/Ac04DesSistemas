using DesSistemas.SnackNow.Api.Domain.Context;
using DesSistemas.SnackNow.Api.Domain.Jobs;
using DesSistemas.SnackNow.Api.Domain.Repositories;
using DesSistemas.SnackNow.Api.Domain.Repositories.Interfaces;
using DesSistemas.SnackNow.Api.Domain.Services;
using DesSistemas.SnackNow.Api.Domain.Services.Interfaces;
using DesSistemas.SnackNow.Api.Integrations.AuthZero;
using DesSistemas.SnackNow.Api.Integrations.AuthZero.Interfaces;
using DesSistemas.SnackNow.Api.Integrations.Messenger;
using DesSistemas.SnackNow.Api.Integrations.Pagarme;
using DesSistemas.SnackNow.Api.Integrations.Pagarme.Interfaces;
using DesSistemas.SnackNow.Api.Integrations.ViaCep;
using DesSistemas.SnackNow.Api.Integrations.ViaCep.Interfaces;
using DesSistemas.SnackNow.MessengerApi.Configuration;
using DesSistemas.SnackNow.RecaptchaHelper;
using DesSistemas.SnackNow.Startup.Configuration;
using DesSistemas.SnackNow.Twillo.Configuration;

namespace DesSistemas.SnackNow.Api.Domain
{
    public static class DependencyInjection
    {
        public static void AddAppDependency(this IServiceCollection services)
        {
            services.AddScoped<SnackNowApiContext>();

            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IEstablishmentRepository, EstablishmentRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUserSystemRepository, UserSystemRepository>();
            services.AddScoped<IUserSystemPassRecoveryRepository, UserSystemPassRecoveryRepository>();
            services.AddScoped<IMessengerMessageRepository, MessengerMessageRepository>();
            services.AddScoped<IBarRepository, BarRepository>();
            services.AddScoped<IDonationRequestRepository, DonationRequestRepository>();
            services.AddScoped<IPaymentsRepository, PaymentsRepository>();

            services.AddTransient<ICrudProductService, CrudProductService>();
            services.AddTransient<ICrudUserSystemService, CrudUserSystemService>();
            services.AddTransient<IAddressSearchService, AddressSearchService>();
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<ICrudEstablishmentService, CrudEstablishmentService>();
            services.AddTransient<IPassRecoveryService, PassRecoveryService>();
            services.AddTransient<IMessengerService, MessengerService>();
            services.AddTransient<IBarService, BarService>();
            services.AddTransient<IDonationRequestService, DonationRequestService>();
            services.AddTransient<IPaymentService, PaymentService>();

            services.AddTransient<IViaCepIntegration, ViaCepIntegration>();
            services.AddTransient<IPagarmeIntegration, PagarmeIntegration>();
            services.AddTransient<IAuthZeroIntegration, AuthZeroIntegration>();
            services.AddTransient<ICheckPaymentsJobService, CheckPaymentsJobService>();

            services.AddHostedService<CheckPendingPaymentsHostedService>();
            services.AddSingleton(new PagarmeConfiguration
            {
                UrlBase = "",
                Key = ""
            });
            services.AddTwillo(new TwilloConfig());
            services.AddReCaptcha(new ReCaptchaConfig());
            services.AddMessengerClient(cfg =>
            {
                cfg.AccessToken = "";
                cfg.VersionApi = "";
                cfg.PageId = "";
                cfg.ImplementationType = typeof(MessengerApiHandler);
            });
        }
    }
}