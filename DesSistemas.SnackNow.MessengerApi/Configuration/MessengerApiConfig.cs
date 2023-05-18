namespace DesSistemas.SnackNow.MessengerApi.Configuration
{
    public class MessengerApiConfig
    {
        public static string Url = "https://graph.facebook.com/";

        public string? VersionApi { get; set; }
        public string? AccessToken { get; set; }
        public string? PageId { get; set; }
        public Type? ImplementationType { get; set; }
    }
}