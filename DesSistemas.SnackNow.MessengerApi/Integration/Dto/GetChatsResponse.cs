using Newtonsoft.Json;

namespace DesSistemas.SnackNow.MessengerApi.Integration.Dto
{
    public class GetChatsResponse
    {
        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("updated_time")]
        public DateTime UpdatedTime { get; set; }
    }
}