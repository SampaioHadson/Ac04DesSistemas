using DesSistemas.SnackNow.Api.Integrations.Pagarme.Dto;

namespace DesSistemas.SnackNow.Api.Integrations.Pagarme.Interfaces
{
    public interface IPagarmeIntegration
    {
        Task<PagarmeOrderResponse> CreateOrderAsync(PagarmeOrderRequest order);
        Task<PagarmeOrderResponse> GetOrderByIdAsync(string orderId);
    }
}