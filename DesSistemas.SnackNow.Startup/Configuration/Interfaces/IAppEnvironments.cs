namespace DesSistemas.SnackNow.Startup.Configuration.Interfaces
{
    public interface IAppEnvironments
    {
        string ViaCepUrlBase { get; }
        AuthZeroConfig AuthZero { get; }
    }
}