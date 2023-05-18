using Newtonsoft.Json;

namespace DesSistemas.SnackNow.Api.Integrations.AuthZero.Dto
{
    public class AuthZeroChangePassRequest
    {
        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("connection")]
        public string Connection { get; set; }

        public AuthZeroChangePassRequest(string password, string connection) 
        {
            Password = password;
            Connection = connection;
        }
    }
}