using DesSistemas.SnackNow.Api.Dto.DonationRequests;

namespace DesSistemas.SnackNow.Api.Domain.Services.Interfaces
{
    public interface IDonationRequestService
    {
        Task AddAsync(DonationRequestAdd add);
        Task<List<DonationRequestListDto>> GetAll();
        Task<DonationRequestImageItem> GetImageAsync(long donationRequestId);
    }
}