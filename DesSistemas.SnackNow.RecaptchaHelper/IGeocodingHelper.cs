namespace DesSistemas.SnackNow.RecaptchaHelper
{
    public interface IGeocodingHelper
    {
        Task<string?> GetAddressAsync(string latitude, string longitude);
    }
}