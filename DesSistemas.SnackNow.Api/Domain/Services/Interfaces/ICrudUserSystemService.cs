using DesSistemas.SnackNow.Api.Dto.UserSystem;

namespace DesSistemas.SnackNow.Api.Domain.Services.Interfaces
{
    public interface ICrudUserSystemService
    {
        Task<long> AddAsync(UserSystemAddRequest request);
    }
}