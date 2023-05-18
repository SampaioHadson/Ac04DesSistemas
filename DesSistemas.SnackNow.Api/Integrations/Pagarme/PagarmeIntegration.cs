using DesSistemas.SnackNow.Api.Integrations.Pagarme.Dto;
using DesSistemas.SnackNow.Api.Integrations.Pagarme.Interfaces;
using DesSistemas.SnackNow.Startup.Configuration;
using DesSistemas.SnackNow.Startup.HttpIntegration.Services.Interfaces;

namespace DesSistemas.SnackNow.Api.Integrations.Pagarme
{
    public class PagarmeIntegration : IPagarmeIntegration
    {
        private readonly IHttpMessageRequestService _httpService;
        private readonly PagarmeConfiguration _config;

        public PagarmeIntegration(IHttpMessageRequestService httpService, PagarmeConfiguration config)
        {
            _httpService = httpService;
            _config = config;
        }

        public async Task<PagarmeOrderResponse> CreateOrderAsync(PagarmeOrderRequest order)
        {
            var endpoint = new CreateOrderEndpoint(order, _config);
            return await endpoint.Execute(_httpService);
        }

        public async Task<PagarmeOrderResponse> GetOrderByIdAsync(string orderId)
        {
            var endpoint = new GetOrderEndpoint(_config, orderId);
            return await endpoint.Execute(_httpService);
        }
    }
}