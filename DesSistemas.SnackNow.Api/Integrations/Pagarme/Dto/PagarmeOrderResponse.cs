using Newtonsoft.Json;

namespace DesSistemas.SnackNow.Api.Integrations.Pagarme.Dto
{
    public class AntifraudResponse
    {
    }

    public class Charge
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("gateway_id")]
        public string GatewayId { get; set; }

        [JsonProperty("amount")]
        public int Amount { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("payment_method")]
        public string PaymentMethod { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("customer")]
        public Customer Customer { get; set; }

        [JsonProperty("last_transaction")]
        public LastTransaction LastTransaction { get; set; }
    }

    public class Customer
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("document")]
        public string Document { get; set; }

        [JsonProperty("document_type")]
        public string DocumentType { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("delinquent")]
        public bool Delinquent { get; set; }

        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [JsonProperty("phones")]
        public Phones Phones { get; set; }
    }

    public class GatewayResponse
    {
    }

    public class Item
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("amount")]
        public int Amount { get; set; }

        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        [JsonProperty("status")]
        public string? Status { get; set; }

        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }
    }

    public class LastTransaction
    {
        [JsonProperty("payer")]
        public Payer Payer { get; set; }

        [JsonProperty("qr_code")]
        public string QrCode { get; set; }

        [JsonProperty("qr_code_url")]
        public string QrCodeUrl { get; set; }

        [JsonProperty("expires_at")]
        public DateTime ExpiresAt { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("transaction_type")]
        public string TransactionType { get; set; }

        [JsonProperty("gateway_id")]
        public string GatewayId { get; set; }

        [JsonProperty("amount")]
        public int Amount { get; set; }

        [JsonProperty("end_to_end_id")]
        public string EndToEndId { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("gateway_response")]
        public GatewayResponse GatewayResponse { get; set; }

        [JsonProperty("antifraud_response")]
        public AntifraudResponse AntifraudResponse { get; set; }

        [JsonProperty("metadata")]
        public Metadata Metadata { get; set; }
    }

    public class BankAccount
    {
        [JsonProperty("bank_name")]
        public string BankName { get; set; }

        [JsonProperty("ispb")]
        public string Ispb { get; set; }
    }

    public class Payer
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("document_type")]
        public string DocumentType { get; set; }

        [JsonProperty("document")]
        public string Document { get; set; }

        [JsonProperty("bank_account")]
        public BankAccount BankAccount { get; set; }
    }

    public class Metadata
    {
    }

    public class PagarmeOrderResponse
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("amount")]
        public int Amount { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("closed")]
        public bool Closed { get; set; }

        [JsonProperty("items")]
        public List<Item> Items { get; set; }

        [JsonProperty("customer")]
        public Customer Customer { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("closed_at")]
        public DateTime ClosedAt { get; set; }

        [JsonProperty("charges")]
        public List<Charge> Charges { get; set; }
    }
}