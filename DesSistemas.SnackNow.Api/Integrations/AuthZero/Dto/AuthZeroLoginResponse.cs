using Newtonsoft.Json;

namespace DesSistemas.SnackNow.Api.Integrations.AuthZero.Dto
{
    public class AuthZeroLoginResponse
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; } = null!;

        [JsonProperty("scope")]
        public string Scope { get; set; } = null!;

        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }

        [JsonProperty("token_type")]
        public string TokenType { get; set; } = null!;
    }
}