using Newtonsoft.Json;

namespace DesSistemas.SnackNow.Api.Integrations.AuthZero.Dto
{
    public class AuthZeroSignUpResponse
    {
        [JsonProperty("given_name")]
        public string? GivenName { get; set; }

        [JsonProperty("family_name")]
        public string? FamilyName { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("nickname")]
        public string? Nickname { get; set; }

        [JsonProperty("_id")]
        public string Id { get; set; } = null!;

        [JsonProperty("email_verified")]
        public bool EmailVerified { get; set; }

        [JsonProperty("email")]
        public string? Email { get; set; }
    }
}