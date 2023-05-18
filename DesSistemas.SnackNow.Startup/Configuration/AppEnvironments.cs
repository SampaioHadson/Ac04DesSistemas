using DesSistemas.SnackNow.Startup.Configuration.Interfaces;

namespace DesSistemas.SnackNow.Startup.Configuration
{
    public class AppEnvironments : IAppEnvironments
    {
        public string ViaCepUrlBase { get; set; } = null!;
        public AuthZeroConfig AuthZero { get; set; } = null!;
    }

    public static class DbConnection
    {
        public static string? ConnectionDatabase { get; set; }
    }
}