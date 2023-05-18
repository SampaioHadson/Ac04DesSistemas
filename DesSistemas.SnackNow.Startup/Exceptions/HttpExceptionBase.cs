using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DesSistemas.SnackNow.Startup.Exceptions
{
    [Serializable]
    public abstract class HttpExceptionBase : Exception
    {
        public abstract int StatusCode { get; }
        protected HttpExceptionBase()
        {
        }

        protected HttpExceptionBase(string? message) : base(message)
        {
        }

        protected HttpExceptionBase(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        protected HttpExceptionBase(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}