using DesSistemas.SnackNow.Api.Domain.Services.Interfaces;
using DesSistemas.SnackNow.MessengerApi.Integration.Dto;
using DesSistemas.SnackNow.MessengerApi.Integration.Interfaces;
using DesSistemas.SnackNow.MessengerApi.Runner.Handlers;

namespace DesSistemas.SnackNow.Api.Integrations.Messenger
{
    public class MessengerApiHandler : IMessengerHandler
    {
        private readonly IMessengerIntegration _messengerIntegration;
        private readonly IMessengerService _messengerService;
        private static int TimeToGetMessagesInMs = 24 * 60 * 60 * 1000;

        public MessengerApiHandler(IMessengerIntegration messengerIntegration,
            IMessengerService messengerService)
        {
            _messengerIntegration = messengerIntegration;
            _messengerService = messengerService;
        }

        public async Task<bool> HandleAsync(MessengerPaginateResponse<GetChatsResponse> chatsReponse, DateTime referenceDate)
        {
            referenceDate = referenceDate.AddMilliseconds(-TimeToGetMessagesInMs);
            var query = chatsReponse.Data.Where(w => w.UpdatedTime >= referenceDate);
            if (!query.Any())
                return false;

            foreach (var chat in query)
                await HandleChatAsync(chat.Id!, referenceDate);

            return true;
        }

        private async Task HandleChatAsync(string chatId, DateTime referenceDate)
        {
            var messages = await _messengerIntegration.GetMessagesAsync(chatId);
            var query = messages.Data.Where(w => w.CreatedTime >= referenceDate);
            while (query.Any())
            {
                await _messengerService.ProcessMessageAsync(query);
                if (string.IsNullOrEmpty(messages.Paging.Next))
                    break;

                messages = await _messengerIntegration.GetMessagesAsync(chatId, messages.Paging.Cursors.After);
                query = messages.Data.Where(w => w.CreatedTime >= referenceDate);
            }
        }
    }
}