using AutoMapper;
using DesSistemas.SnackNow.Api.Domain.Entities;
using DesSistemas.SnackNow.Api.Domain.Repositories.Interfaces;
using DesSistemas.SnackNow.Api.Dto.Bars;

namespace DesSistemas.SnackNow.Api.Domain.Services
{
    public class BarService : IBarService
    {
        private readonly IBarRepository _barRepository;
        private readonly IMapper _mapper;

        public BarService(IBarRepository barRepository, IMapper mapper)
        {
            _barRepository = barRepository;
            _mapper = mapper;
        }

        public async Task AddAsync(BarAddRequest request)
        {
            var entity = _mapper.Map<BarEntity>(request);
            await _barRepository.AddAsync(entity);
        }

        public async Task<List<BarEntity>> GetAllAsync()
        {
            var result = await _barRepository.GetAll();
            return result;
        }
    }
}
