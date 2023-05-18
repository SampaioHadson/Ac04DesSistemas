using DesSistemas.SnackNow.Api.Domain.Entities;
using DesSistemas.SnackNow.Api.Dto.DonationRequests;
using DesSistemas.SnackNow.Startup.ApiLayers.Database;

namespace DesSistemas.SnackNow.Api.Domain.Repositories.Interfaces
{
    public interface IDonationRequestRepository : IRepositoryBase<DonationRequest, long>
    {
        Task<List<DonationRequestListDto>> GetAll();
        Task<DonationRequestImage?> GetByDonationRequestId(long requestId);
    }
}