namespace DesSistemas.SnackNow.Startup.Guard
{
    public static partial class Guard
    {
        public static void Null(object? value, Func<Exception> func)
        {
            if (value is null)
            {
                throw func.Invoke();
            }
        }
    }
}