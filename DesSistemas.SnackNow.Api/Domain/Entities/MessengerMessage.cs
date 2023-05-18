using DesSistemas.SnackNow.Startup.ApiLayers.Database;

namespace DesSistemas.SnackNow.Api.Domain.Entities
{
    public class MessengerMessage : EntityBase<long>
    {
        public string? MessageId { get; set; }
        public DateTime ReferenceDate { get; set; }
        public string? From { get; set; }
        public string? MessageContent { get; set; }

        public MessengerMessage() { }

        public MessengerMessage(string messageId,
            DateTime referenceDate,
            string from,
            string messageContent)
        {
            MessageId = messageId;
            ReferenceDate = referenceDate;
            From = from;
            MessageContent = messageContent;
        }
    }
}