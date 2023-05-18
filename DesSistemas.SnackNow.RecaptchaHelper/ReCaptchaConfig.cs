namespace DesSistemas.SnackNow.RecaptchaHelper
{
    public class ReCaptchaConfig
    {
        public string Url { get; set; } = "https://www.google.com/recaptcha/api/siteverify";
        public string GeocodingUrl { get; set; } = "https://maps.googleapis.com/maps/api/geocode/json";
        public string Secret { get; set; } = "";
        public string Key { get; set; } = "";
    }
}