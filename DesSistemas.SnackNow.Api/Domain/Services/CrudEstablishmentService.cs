using DesSistemas.SnackNow.Api.Domain.Entities;
using DesSistemas.SnackNow.Api.Domain.Repositories.Interfaces;
using DesSistemas.SnackNow.Api.Domain.Services.Interfaces;
using DesSistemas.SnackNow.Api.Dto.Establishments;
using DesSistemas.SnackNow.Api.Dto.Product;
using DesSistemas.SnackNow.Startup.ApiLayers.Database;
using DesSistemas.SnackNow.Startup.Exceptions;
using DesSistemas.SnackNow.Startup.Guard;

namespace DesSistemas.SnackNow.Api.Domain.Services
{
    public class CrudEstablishmentService : ICrudEstablishmentService
    {
        private readonly IEstablishmentRepository _establishmentRepository;

        public CrudEstablishmentService(IEstablishmentRepository establishmentRepository)
        {
            _establishmentRepository = establishmentRepository;
        }

        public async Task<long> AddAsync(EstablishmentAddRequest request)
        {
            Guard.NullOrEmpty(request.Description, () => new HttpBadRequestException("O campo Description é obrigatório"));
            Guard.NullOrEmpty(request.Name, () => new HttpBadRequestException("O campo Name é obrigatório"));

            var entity = new Establishment(request);
            return await _establishmentRepository.AddAsync(entity);
        }

        public async Task<Establishment> GetByIdAsync(long id, bool active = true, bool tracking = false)
        {
            var entity = await _establishmentRepository.GetByIdAsync(id, active, tracking);
            Guard.Null(entity, () => new HttpNotFoundException("Estabelecimento não encontrado."));

            return entity!;
        }

        public async Task UpdateAsync(EstablishmentAddRequest request, long id)
        {
            Guard.NullOrEmpty(request.Description, () => new HttpBadRequestException("O campo Description é obrigatório"));
            Guard.NullOrEmpty(request.Name, () => new HttpBadRequestException("O campo Name é obrigatório"));

            var entity = await GetByIdAsync(id, tracking: true);
            entity.Update(request);
            await _establishmentRepository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(long id)
        {
            var entity = await GetByIdAsync(id, tracking: true);
            await _establishmentRepository.DeleteAsync(entity);
        }

        public async Task<PaginationResponseBase<Establishment>> GetAllAsync(QueryPaginationRequest pagination, QueryFilterBase filter)
        {
            return await _establishmentRepository.GetAllAsync(pagination, filter);
        }
    }
}