using DesSistemas.SnackNow.Startup.ApiLayers.Database;

namespace DesSistemas.SnackNow.Api.Domain.Entities
{
    public class ProductCategory : EntityBase<long>
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;

        public ProductCategory() { }

        public ProductCategory(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}