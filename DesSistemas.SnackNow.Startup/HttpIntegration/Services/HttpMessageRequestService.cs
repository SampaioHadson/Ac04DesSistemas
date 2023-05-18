using DesSistemas.SnackNow.Startup.Exceptions;
using DesSistemas.SnackNow.Startup.HttpIntegration.Dto;
using DesSistemas.SnackNow.Startup.HttpIntegration.Services.Interfaces;
using Newtonsoft.Json;

namespace DesSistemas.SnackNow.Startup.HttpIntegration.Services
{
    public class HttpMessageRequestService : IHttpMessageRequestService
    {
        public async Task<HttpDefaultMessageResponseDto> ExecuteAsync(HttpMessageRequestDto request)
        {
            using var httpClient = new HttpClient();
            BindHeaders(httpClient, request);
            var result = await ExecuteAsync(httpClient, request);
            var contentStr = await result.Content.ReadAsStringAsync();
            return new HttpDefaultMessageResponseDto(contentStr, (int)result.StatusCode);
        }

        public async Task<HttpMessageResponseDto<TContent>> ExecuteAsync<TContent>(HttpMessageRequestDto request)
        {
            using var httpClient = new HttpClient();
            BindHeaders(httpClient, request);
            var result = await ExecuteAsync(httpClient, request);
            var contentStr = await result.Content.ReadAsStringAsync();
            var content = JsonConvert.DeserializeObject<TContent>(contentStr)!;
            return new HttpMessageResponseDto<TContent>(content, (int)result.StatusCode);
        }

        private Task<HttpResponseMessage> ExecuteAsync(HttpClient httpClient, HttpMessageRequestDto request)
        {
            return request.Method switch
            {
                Enum.HttpMessageRequestMethod.GET => httpClient.GetAsync(request.Url),
                Enum.HttpMessageRequestMethod.POST => httpClient.PostAsync(request.Url, request.Content),
                Enum.HttpMessageRequestMethod.PUT => httpClient.PutAsync(request.Url, request.Content),
                Enum.HttpMessageRequestMethod.DELETE => httpClient.DeleteAsync(request.Url),
                Enum.HttpMessageRequestMethod.PATCH => httpClient.PatchAsync(request.Url, request.Content),
                _ => throw new HttpInternalServerErrorException("Tipo de requisição inválida."),
            };
        }

        private void BindHeaders(HttpClient client, HttpMessageRequestDto request)
        {
            if (request.Headers == null)
                return;

            foreach (var header in request.Headers)
            {
                if (client.DefaultRequestHeaders.Contains(header.Key))
                    client.DefaultRequestHeaders.Remove(header.Key);

                client.DefaultRequestHeaders.Add(header.Key, header.Value);
            }
        }
    }
}