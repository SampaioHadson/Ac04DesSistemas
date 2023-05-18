using DesSistemas.SnackNow.MessengerApi.Integration.Dto;

namespace DesSistemas.SnackNow.Api.Domain.Services.Interfaces
{
    public interface IMessengerService
    {
        Task ProcessMessageAsync(IEnumerable<GetMessagesReponse> messageReponse);
    }
}