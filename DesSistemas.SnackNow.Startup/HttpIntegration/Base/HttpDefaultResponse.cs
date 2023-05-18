namespace DesSistemas.SnackNow.Startup.HttpIntegration.Base
{
    public class HttpDefaultResponse<TValue>
    {
        public TValue Value { get; set; }

        public HttpDefaultResponse(TValue value)
        {
            Value = value;
        }
    }
}