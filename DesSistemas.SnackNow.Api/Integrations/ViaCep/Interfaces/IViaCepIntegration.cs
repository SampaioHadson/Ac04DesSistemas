using DesSistemas.SnackNow.Api.Integrations.ViaCep.Dto;

namespace DesSistemas.SnackNow.Api.Integrations.ViaCep.Interfaces
{
    public interface IViaCepIntegration
    {
        Task<ViaCepResponse> GetByPostalCode(string postalCode);
    }
}