using DesSistemas.SnackNow.Api.Integrations.ViaCep.Dto;
using DesSistemas.SnackNow.Api.Integrations.ViaCep.Interfaces;
using DesSistemas.SnackNow.Startup.Configuration.Interfaces;
using DesSistemas.SnackNow.Startup.Exceptions;
using DesSistemas.SnackNow.Startup.Guard;
using DesSistemas.SnackNow.Startup.HttpIntegration.Builder;
using DesSistemas.SnackNow.Startup.HttpIntegration.Services.Interfaces;

namespace DesSistemas.SnackNow.Api.Integrations.ViaCep
{
    public class ViaCepIntegration : IViaCepIntegration
    {
        private readonly IHttpMessageRequestService _httpService;
        private readonly IAppEnvironments _env;

        private const string FaultMessage = "Ocorreu um erro ao buscar endereço. Por favor, tente novamente mais tarde.";

        public ViaCepIntegration(IHttpMessageRequestService httpService, IAppEnvironments env)
        {
            _httpService = httpService;
            _env = env;
        }

        public async Task<ViaCepResponse> GetByPostalCode(string postalCode)
        {
            var url = string.Format(_env.ViaCepUrlBase, postalCode);
            var request = new HttpMessageRequestBuilder()
                .WithUrl(url)
                .Get()
                .Build();

            var result = await _httpService.ExecuteAsync<ViaCepResponse>(request);

            Guard.False(result.IsSuccess, () => new HttpInternalServerErrorException(FaultMessage));
            Guard.Null(result.Content, () => new HttpInternalServerErrorException(FaultMessage));

            return result.Content;
        }
    }
}