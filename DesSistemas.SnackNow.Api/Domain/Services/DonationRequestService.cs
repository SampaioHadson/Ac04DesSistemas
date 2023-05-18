using AutoMapper;
using DesSistemas.SnackNow.Api.Domain.Entities;
using DesSistemas.SnackNow.Api.Domain.Repositories.Interfaces;
using DesSistemas.SnackNow.Api.Domain.Services.Interfaces;
using DesSistemas.SnackNow.Api.Dto.DonationRequests;

namespace DesSistemas.SnackNow.Api.Domain.Services
{
    public class DonationRequestService : IDonationRequestService
    {
        private readonly IDonationRequestRepository _donationRequestRepository;
        private readonly IMapper _mapper;

        public DonationRequestService(IDonationRequestRepository donationRequestRepository,
            IMapper mapper)
        {
            _donationRequestRepository = donationRequestRepository;
            _mapper = mapper;
        }

        public async Task AddAsync(DonationRequestAdd add)
        {
            var entity = new DonationRequest
            {
                AmountToRaise = add.AmountToRaise,
                AnimalName = add.AnimalName,
                Description = add.Description,
                DonationRequestImage = new DonationRequestImage
                {
                    ImageBase64 = add.ImageBase64
                }
            };

            await _donationRequestRepository.AddAsync(entity);
        }

        public async Task<DonationRequestImageItem> GetImageAsync(long donationRequestId)
        {
            var entity = await _donationRequestRepository.GetByDonationRequestId(donationRequestId);
            return new DonationRequestImageItem
            {
                Base64 = entity!.ImageBase64
            };
        }

        public async Task<List<DonationRequestListDto>> GetAll()
        {
            return await _donationRequestRepository.GetAll();
        }
    }
}