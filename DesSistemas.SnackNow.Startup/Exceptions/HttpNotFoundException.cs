using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DesSistemas.SnackNow.Startup.Exceptions
{
    [Serializable]
    public class HttpNotFoundException : HttpExceptionBase
    {
        public HttpNotFoundException()
        {
        }

        public HttpNotFoundException(string? message) : base(message)
        {
        }

        public HttpNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public HttpNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        public override int StatusCode => 404;
    }
}
