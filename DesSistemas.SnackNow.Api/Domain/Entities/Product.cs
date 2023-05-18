using DesSistemas.SnackNow.Api.Dto.Product;
using DesSistemas.SnackNow.Startup.ApiLayers.Database;

namespace DesSistemas.SnackNow.Api.Domain.Entities
{
    public class Product : EntityBase<long>
    {
        public string Name { get; set; } = null!;
        public decimal Value { get; set; }
        public ProductCategory? Category { get; set; }
        public long? ProductCategoryId { get; set; }

        public Product() { }

        public Product(ProductAddRequest request)
        {
            Update(request);
        }

        public Product Update(ProductAddRequest request)
        {
            Name = request.Name;
            Value = request.Value;

            return this;
        }
    }
}