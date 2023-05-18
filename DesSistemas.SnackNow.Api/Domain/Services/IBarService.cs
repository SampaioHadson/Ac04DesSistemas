using DesSistemas.SnackNow.Api.Domain.Entities;
using DesSistemas.SnackNow.Api.Dto.Bars;

namespace DesSistemas.SnackNow.Api.Domain.Services
{
    public interface IBarService
    {
        Task AddAsync(BarAddRequest request);
        Task<List<BarEntity>> GetAllAsync();
    }
}