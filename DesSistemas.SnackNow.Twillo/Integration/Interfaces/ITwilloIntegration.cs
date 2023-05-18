namespace DesSistemas.SnackNow.Twillo.Integration.Interfaces
{
    public interface ITwilloIntegration
    {
        Task SendSmsAsync(string to, string message);
    }
}