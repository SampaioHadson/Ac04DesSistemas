using Newtonsoft.Json;

namespace DesSistemas.SnackNow.MessengerApi.Integration.Dto
{
    public class GetMessagesReponse
    {
        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("created_time")]
        public DateTime CreatedTime { get; set; }

        [JsonProperty("message")]
        public string? Message { get; set; }

        [JsonProperty("from")]
        public FromMessageResponse? From { get; set; }
    }

    public class FromMessageResponse
    {
        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("email")]
        public string? Email { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }
    }
}