using Newtonsoft.Json;

namespace DesSistemas.SnackNow.MessengerApi.Integration.Dto
{
    public class MessengerPaginateResponse<T>
    {
        [JsonProperty("data")]
        public List<T> Data { get; set; }

        [JsonProperty("paging")]
        public MessengerPaginateResponseDetails Paging { get; set; }
    }

    public class MessengerPaginateResponseDetails
    {
        [JsonProperty("cursors")]
        public MessengerPaginateResponseCursors Cursors { get; set; }

        [JsonProperty("next")]
        public string Next { get; set; }
    }

    public class MessengerPaginateResponseCursors
    {
        [JsonProperty("before")]
        public string Before { get; set; }
        
        [JsonProperty("after")]
        public string After { get; set; }
    }
}