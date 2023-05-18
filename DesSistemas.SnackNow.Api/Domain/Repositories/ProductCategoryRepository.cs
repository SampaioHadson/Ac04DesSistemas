using DesSistemas.SnackNow.Api.Domain.Context;
using DesSistemas.SnackNow.Api.Domain.Entities;
using DesSistemas.SnackNow.Api.Domain.Repositories.Interfaces;
using DesSistemas.SnackNow.Startup.ApiLayers.Database;

namespace DesSistemas.SnackNow.Api.Domain.Repositories
{
    public class ProductCategoryRepository : RepositoryBase<ProductCategory, long, SnackNowApiContext>, IProductCategoryRepository
    {
        public ProductCategoryRepository(SnackNowApiContext context) : base(context)
        {
        }
    }
}