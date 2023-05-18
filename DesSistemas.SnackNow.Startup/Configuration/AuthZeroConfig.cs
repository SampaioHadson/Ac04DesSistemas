using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesSistemas.SnackNow.Startup.Configuration
{
    public class AuthZeroConfig
    {
        public string UrlBase { get; set; } = null!;
        public string ClientId { get; set; } = null!;
        public string ClientSecret { get; set; } = null!;
        public string ClientConnection { get; set; } = null!;
        public string Audience { get; set; } = null!;
    }
}