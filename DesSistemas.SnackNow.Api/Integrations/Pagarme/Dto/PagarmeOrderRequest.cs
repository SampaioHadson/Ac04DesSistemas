using Newtonsoft.Json;

namespace DesSistemas.SnackNow.Api.Integrations.Pagarme.Dto
{
    public class HomePhone
    {
        [JsonProperty("country_code")]
        public string CountryCode { get; set; }

        [JsonProperty("area_code")]
        public string AreaCode { get; set; }

        [JsonProperty("number")]
        public string Number { get; set; }
    }

    public class Payment
    {
        [JsonProperty("payment_method")]
        public string PaymentMethod { get; set; }

        [JsonProperty("pix")]
        public Pix Pix { get; set; }
    }

    public class Phones
    {
        [JsonProperty("home_phone")]
        public HomePhone HomePhone { get; set; }
    }

    public class Pix
    {
        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }
    }

    public class PagarmeOrderRequest
    {
        [JsonProperty("customer")]
        public Customer Customer { get; set; }

        [JsonProperty("items")]
        public List<Item> Items { get; set; }

        [JsonProperty("payments")]
        public List<Payment> Payments { get; set; }
    }
}
