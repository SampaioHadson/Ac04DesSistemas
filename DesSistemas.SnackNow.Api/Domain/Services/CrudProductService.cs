using AutoMapper;
using DesSistemas.SnackNow.Api.Domain.Entities;
using DesSistemas.SnackNow.Api.Domain.Repositories.Interfaces;
using DesSistemas.SnackNow.Api.Domain.Services.Interfaces;
using DesSistemas.SnackNow.Api.Dto.Product;
using DesSistemas.SnackNow.Startup.ApiLayers.Database;
using DesSistemas.SnackNow.Startup.Exceptions;
using DesSistemas.SnackNow.Startup.Guard;

namespace DesSistemas.SnackNow.Api.Domain.Services
{
    public class CrudProductService : ICrudProductService
    {
        private readonly IProductRepository _productRepository;

        public CrudProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<long> AddAsync(ProductAddRequest request)
        {
            Guard.NullOrEmpty(request.Name, () => new HttpBadRequestException("O campo Name é obrigatório"));
            Guard.Range(request.Value, 0.1m, decimal.MaxValue, () => new HttpBadRequestException("O campo Valor deve ser maior que 0.1"));

            var entity = new Product(request);
            return await _productRepository.AddAsync(entity);
        }

        public async Task<Product> GetByIdAsync(long id, bool active = true, bool tracking = false)
        {
            var entity = await _productRepository.GetByIdAsync(id);
            Guard.Null(entity, () => new HttpNotFoundException("Produto não encontrado."));

            return entity!;
        }

        public async Task UpdateAsync(ProductAddRequest request, long id)
        {
            var entity = await GetByIdAsync(id, tracking: true);
            entity.Update(request);

            await _productRepository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(long id)
        {
            var entity = await GetByIdAsync(id, tracking: true);
            await _productRepository.DeleteAsync(entity);
        }

        public async Task<PaginationResponseBase<Product>> GetAllAsync(QueryPaginationRequest pagination, QueryFilterBase filter)
        {
            return await _productRepository.GetAllAsync(pagination, filter);
        }
    }
}