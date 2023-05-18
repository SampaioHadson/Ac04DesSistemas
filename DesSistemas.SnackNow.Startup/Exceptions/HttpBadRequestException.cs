using System.Runtime.Serialization;

namespace DesSistemas.SnackNow.Startup.Exceptions
{
    [Serializable]
    public class HttpBadRequestException : HttpExceptionBase
    {
        public HttpBadRequestException()
        {
        }

        public HttpBadRequestException(string? message) : base(message)
        {
        }

        public HttpBadRequestException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public HttpBadRequestException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        public override int StatusCode => 400;
    }
}