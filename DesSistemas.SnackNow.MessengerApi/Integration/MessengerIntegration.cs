using DesSistemas.SnackNow.MessengerApi.Configuration;
using DesSistemas.SnackNow.MessengerApi.Integration.Dto;
using DesSistemas.SnackNow.MessengerApi.Integration.Interfaces;
using DesSistemas.SnackNow.Startup.HttpIntegration.Services.Interfaces;

namespace DesSistemas.SnackNow.MessengerApi.Integration
{
    public class MessengerIntegration : IMessengerIntegration
    {
        private readonly IHttpMessageRequestService _httpService;
        private readonly string _accessToken;
        private readonly string _urlbase;
        private readonly string _pageId;

        public MessengerIntegration(IHttpMessageRequestService httpService, MessengerApiConfig config)
        {
            _httpService = httpService;
            _urlbase = $"{MessengerApiConfig.Url}{config.VersionApi}";
            _accessToken = config.AccessToken!;
            _pageId = config.PageId!;
        }

        public async Task<MessengerPaginateResponse<GetChatsResponse>> GetChatsAsync(string? after = null)
        {
            var requestExecutor = new GetChatsEndpoint(_urlbase, _pageId, _accessToken, after);
            return await requestExecutor.Execute(_httpService);
        }

        public async Task<MessengerPaginateResponse<GetMessagesReponse>> GetMessagesAsync(string chatId, string? after = null)
        {
            var requestExecutor = new GetMessagesEndpoint(_urlbase, chatId, _accessToken, after);
            return await requestExecutor.Execute(_httpService);
        }
    }
}