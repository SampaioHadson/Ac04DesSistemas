using System.Runtime.Serialization;

namespace DesSistemas.SnackNow.Startup.Exceptions
{
    public class HttpInternalServerErrorException : HttpExceptionBase
    {
        public HttpInternalServerErrorException()
        {
        }

        public HttpInternalServerErrorException(string? message) : base(message)
        {
        }

        public HttpInternalServerErrorException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public HttpInternalServerErrorException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        public override int StatusCode => 500;
    }
}