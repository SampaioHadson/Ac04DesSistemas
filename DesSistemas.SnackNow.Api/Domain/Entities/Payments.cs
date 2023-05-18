using DesSistemas.SnackNow.Api.Domain.Enums;
using DesSistemas.SnackNow.Startup.ApiLayers.Database;

namespace DesSistemas.SnackNow.Api.Domain.Entities
{
    public class Payments : EntityBase<long>
    {
        public DonationRequest DonationRequest { get; set; }
        public long DonationRequestId { get; set; }
        public string PayerName { get; set; }
        public string PayerDocument { get; set; }
        public string PayerCellphone { get; set; }
        public string? EndToEndId { get; set; }
        public string OrderId { get; set; }
        public decimal ValuePaid { get; set; }
        public string QrCode { get; set; }
        public string QrCodeUrl { get; set; }
        public PaymentStatus Status { get; set; }
    }
}