using DesSistemas.SnackNow.MessengerApi.Integration.Dto;
using DesSistemas.SnackNow.Startup.HttpIntegration.Base;
using DesSistemas.SnackNow.Startup.HttpIntegration.Builder;
using DesSistemas.SnackNow.Startup.HttpIntegration.Dto;

namespace DesSistemas.SnackNow.MessengerApi.Integration
{
    public class GetChatsEndpoint : HttpEndpointExecuteBase<MessengerPaginateResponse<GetChatsResponse>>
    {
        private readonly string _url;
        private readonly string _accessToken;
        private readonly string? _after;

        public GetChatsEndpoint(string urlBase, string pageId, string accessToken, string? after = null)
        {
            _url = $"{urlBase}/{pageId}/conversations";
            _accessToken = accessToken;
            _after = after;
        }

        protected override HttpMessageRequestDto BuildRequest()
        {
            var builder = new HttpMessageRequestBuilder()
                .Get()
                .WithParam("access_token", _accessToken)
                .WithParam("fields", "message_count,updated_time")
                .WithUrl(_url);

            if (!string.IsNullOrEmpty(_after))
                builder.WithParam("after", _after);

            return builder.Build();
        }
    }
}