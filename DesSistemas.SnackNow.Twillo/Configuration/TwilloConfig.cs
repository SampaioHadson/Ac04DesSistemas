namespace DesSistemas.SnackNow.Twillo.Configuration
{
    public class TwilloConfig
    {
        public string UrlBase { get; set; } = "https://api.twilio.com";
        public string MessagingServiceSid { get; set; } = "";
        public string Token { get; set; } = "";
        public string Secrect { get; set; } = "";
    }
}