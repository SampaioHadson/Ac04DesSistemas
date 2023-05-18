using DesSistemas.SnackNow.MessengerApi.Integration.Dto;

namespace DesSistemas.SnackNow.MessengerApi.Runner.Handlers
{
    public class DefaultMessengerChatHandler : IMessengerHandler
    {
        public Task<bool> HandleAsync(MessengerPaginateResponse<GetChatsResponse> chatsReponse, DateTime referenceDate)
        {
            Console.WriteLine("Thats not implemented.");
            return Task.FromResult(false);
        }
    }
}