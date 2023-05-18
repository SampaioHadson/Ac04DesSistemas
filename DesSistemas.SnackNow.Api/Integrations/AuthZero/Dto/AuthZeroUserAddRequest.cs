using DesSistemas.SnackNow.Api.Dto.UserSystem;
using Newtonsoft.Json;

namespace DesSistemas.SnackNow.Api.Integrations.AuthZero.Dto
{
    public class AuthZeroUserAddRequest
    {
        [JsonProperty("client_id")]
        public string ClientId { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("connection")]
        public string Connection { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("given_name")]
        public string GivenName { get; set; }

        [JsonProperty("family_name")]
        public string FamilyName { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("nickname")]
        public string Nickname { get; set; }

        public AuthZeroUserAddRequest(UserSystemAddRequest request, string clientId, string clientConnection)
        {
            Name = request.Name;
            Nickname = request.Nickname;
            Email = request.Email;
            Password = request.Password;
            GivenName = request.GivenName;
            FamilyName = request.FamilyName;
            ClientId = clientId;
            Connection = clientConnection;
            Username = request.Username;
        }
    }
}