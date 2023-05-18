namespace DesSistemas.SnackNow.Api.Dto.Address
{
    public class AddressItemResponse
    {
        public long Id { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public string? PostalCode { get; set; }
        public string? State { get; set; }
        public string? Neighborhood { get; set; }
    }
}