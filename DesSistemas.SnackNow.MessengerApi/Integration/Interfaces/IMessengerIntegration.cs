using DesSistemas.SnackNow.MessengerApi.Integration.Dto;

namespace DesSistemas.SnackNow.MessengerApi.Integration.Interfaces
{
    public interface IMessengerIntegration
    {
        Task<MessengerPaginateResponse<GetChatsResponse>> GetChatsAsync(string? after = null);
        Task<MessengerPaginateResponse<GetMessagesReponse>> GetMessagesAsync(string chatId, string? after = null);
    }
}