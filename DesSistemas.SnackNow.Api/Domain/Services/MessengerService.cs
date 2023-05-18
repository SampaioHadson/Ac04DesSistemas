using DesSistemas.SnackNow.Api.Domain.Entities;
using DesSistemas.SnackNow.Api.Domain.Repositories.Interfaces;
using DesSistemas.SnackNow.Api.Domain.Services.Interfaces;
using DesSistemas.SnackNow.MessengerApi.Integration.Dto;
using DesSistemas.SnackNow.Twillo.Integration.Interfaces;

namespace DesSistemas.SnackNow.Api.Domain.Services
{
    public class MessengerService : IMessengerService
    {
        private readonly IMessengerMessageRepository _messengerMessageRepository;
        private readonly ITwilloIntegration _twilloIntegration;
        private const string To = "+5569981088958";

        public MessengerService(IMessengerMessageRepository messengerMessageRepository,
            ITwilloIntegration twilloIntegration)
        {
            _messengerMessageRepository = messengerMessageRepository;
            _twilloIntegration = twilloIntegration;
        }

        public async Task ProcessMessageAsync(IEnumerable<GetMessagesReponse> messageReponse)
        {
            foreach (var message in messageReponse) 
            { 
                var messageExists = await _messengerMessageRepository.HasAnyWithId(message.Id!);
                if (messageExists)
                    continue;

                var messageEntity = new MessengerMessage(message.Id!, message.CreatedTime, message.From!.Name!, message.Message!);
                await _messengerMessageRepository.AddAsync(messageEntity);
                //Console.WriteLine($"{messageEntity.MessageContent} - {message.From}");
                await SendSmsMessageAsync(messageEntity.MessageContent!, messageEntity.From!);
            }
        }

        private async Task SendSmsMessageAsync(string messageContent, string from)
        {
            if (from.Length > 15) 
                from = from.Substring(0, 15);

            if (messageContent.Length > 30)
                messageContent = messageContent.Substring(0, 30);

            var finalMessage = $"{from}: {messageContent}";
            await _twilloIntegration.SendSmsAsync(To, finalMessage);
        }
    }
}