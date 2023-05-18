namespace DesSistemas.SnackNow.Startup.Guard
{
    public static partial class Guard
    {
        public static void True(bool condition, Func<Exception> func)
        {
            if (condition)
            {
                throw func.Invoke();
            }
        }
        
        public static async Task TrueAsync(Task<bool> condition, Func<Exception> func)
        {
            if (await condition)
            {
                throw func.Invoke();
            }
        }

        public static void False(bool condition, Func<Exception> func)
        {
            if (!condition)
            {
                throw func.Invoke();
            }
        }
    }
}