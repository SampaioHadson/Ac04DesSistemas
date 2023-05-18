using DesSistemas.SnackNow.Startup.HttpIntegration.Dto;
using DesSistemas.SnackNow.Startup.HttpIntegration.Services.Interfaces;

namespace DesSistemas.SnackNow.Startup.HttpIntegration.Base
{
    public abstract class HttpEndpointExecuteBase<TResponse>
    {
        protected abstract HttpMessageRequestDto BuildRequest();

        protected virtual void Validate(HttpMessageResponseDto<TResponse> response)
        {
            //Optional Implements
        }

        public virtual async Task<TResponse> Execute(IHttpMessageRequestService messageRequestService)
        {
            var request = BuildRequest();
            var response = await messageRequestService.ExecuteAsync<TResponse>(request);
            Validate(response);
            return response.Content;
        }
    }
}