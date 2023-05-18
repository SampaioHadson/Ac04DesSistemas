using DesSistemas.SnackNow.Api.Integrations.Pagarme.Dto;
using DesSistemas.SnackNow.Startup.Configuration;
using DesSistemas.SnackNow.Startup.HttpIntegration.Base;
using DesSistemas.SnackNow.Startup.HttpIntegration.Builder;
using DesSistemas.SnackNow.Startup.HttpIntegration.Dto;
using System.Text;

namespace DesSistemas.SnackNow.Api.Integrations.Pagarme
{
    public class CreateOrderEndpoint : HttpEndpointExecuteBase<PagarmeOrderResponse>
    {
        private readonly PagarmeOrderRequest _request;
        private readonly PagarmeConfiguration _config;

        public CreateOrderEndpoint(PagarmeOrderRequest request,
            PagarmeConfiguration config)
        {
            _request = request;
            _config = config;
        }

        protected override HttpMessageRequestDto BuildRequest()
        {
            var headerAuth = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{_config.Key}:"));
            return new HttpMessageRequestBuilder()
                .Post()
                .WithUrl($"{_config.UrlBase}/orders")
                .WithJsonBody(_request)
                .WithHeader("Authorization", $"Basic {headerAuth}")
                .Build();
        }
    }
}
