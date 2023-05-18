using DesSistemas.SnackNow.Startup.ApiLayers;

namespace DesSistemas.SnackNow.Api.Dto.Product
{
    public class ProductItemResponse : ResponseItemBase<long>
    {
        public string? Name { get; set; }
        public decimal Value { get; set; }
    }
}