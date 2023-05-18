using Newtonsoft.Json;

namespace DesSistemas.SnackNow.Api.Integrations.ViaCep.Dto
{
    public class ViaCepResponse
    {
        [JsonProperty("cep")]
        public string? PostalCode { get; set; }

        [JsonProperty("logradouro")]
        public string? Street { get; set; }

        [JsonProperty("complemento")]
        public string? Complement { get; set; }

        [JsonProperty("bairro")]
        public string? Neighborhood { get; set; }

        [JsonProperty("localidade")]
        public string? City { get; set; }

        [JsonProperty("uf")]
        public string? State { get; set; }

        [JsonProperty("ibge")]
        public string? Ibge { get; set; }

        [JsonProperty("gia")]
        public string? Gia { get; set; }

        [JsonProperty("ddd")]
        public string? Ddd { get; set; }

        [JsonProperty("siafi")]
        public string? Siafi { get; set; }
    }
}