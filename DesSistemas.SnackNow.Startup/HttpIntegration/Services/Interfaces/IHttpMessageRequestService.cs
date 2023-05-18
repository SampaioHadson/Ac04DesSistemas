using DesSistemas.SnackNow.Startup.HttpIntegration.Dto;

namespace DesSistemas.SnackNow.Startup.HttpIntegration.Services.Interfaces
{
    public interface IHttpMessageRequestService
    {
        Task<HttpDefaultMessageResponseDto> ExecuteAsync(HttpMessageRequestDto request);
        Task<HttpMessageResponseDto<TContent>> ExecuteAsync<TContent>(HttpMessageRequestDto request);
    }
}