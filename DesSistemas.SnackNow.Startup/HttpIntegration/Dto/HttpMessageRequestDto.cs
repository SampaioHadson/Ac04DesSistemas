using DesSistemas.SnackNow.Startup.HttpIntegration.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesSistemas.SnackNow.Startup.HttpIntegration.Dto
{
    public class HttpMessageRequestDto
    {
        public string? Url { get; set; }
        public HttpMessageRequestMethod Method { get; set; }
        public Dictionary<string, string>? Headers { get; set; }
        public Dictionary<string, string>? QueryParams { get; set; }
        public ByteArrayContent? Content { get; set; }
    }
}