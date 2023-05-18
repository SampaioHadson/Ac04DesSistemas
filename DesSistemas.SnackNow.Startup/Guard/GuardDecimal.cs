namespace DesSistemas.SnackNow.Startup.Guard
{
    public static partial class Guard
    {
        public static void Range(decimal value, decimal minValue, decimal maxValue, Func<Exception> func)
        {
            if (value < minValue || value > maxValue)
            {
                throw func.Invoke();
            }
        }
    }
}