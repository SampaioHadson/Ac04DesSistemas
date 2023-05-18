namespace DesSistemas.SnackNow.Startup.Guard
{
    public static partial class Guard
    {
        public static void Null(string? value, Func<Exception> func)
        {
            if (value is null)
            {
                throw func.Invoke();
            }
        }

        public static void NullOrEmpty(string? value, Func<Exception> func)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw func.Invoke();
            }
        }

        public static void NotExactlyLength(string? value, int length, Func<Exception> func)
        {
            NullOrEmpty(value, func);
            if (value!.Length != length)
            {
                throw func.Invoke();
            }
        }
    }
}