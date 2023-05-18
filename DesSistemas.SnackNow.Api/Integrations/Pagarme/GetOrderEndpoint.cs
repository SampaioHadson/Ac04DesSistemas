using DesSistemas.SnackNow.Api.Integrations.Pagarme.Dto;
using DesSistemas.SnackNow.Startup.Configuration;
using DesSistemas.SnackNow.Startup.HttpIntegration.Base;
using DesSistemas.SnackNow.Startup.HttpIntegration.Builder;
using DesSistemas.SnackNow.Startup.HttpIntegration.Dto;
using System.Text;

namespace DesSistemas.SnackNow.Api.Integrations.Pagarme
{
    public class GetOrderEndpoint : HttpEndpointExecuteBase<PagarmeOrderResponse>
    {
        private readonly string _orderId;
        private readonly PagarmeConfiguration _config;

        public GetOrderEndpoint(PagarmeConfiguration config, string orderId)
        {
            _config = config;
            _orderId = orderId;
        }

        protected override HttpMessageRequestDto BuildRequest()
        {
            var headerAuth = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{_config.Key}:"));
            return new HttpMessageRequestBuilder()
                .Get()
                .WithUrl($"{_config.UrlBase}/orders/{_orderId}")
                .WithHeader("Authorization", $"Basic {headerAuth}")
                .Build();
        }
    }
}