using DesSistemas.SnackNow.Api.Domain.Context;
using DesSistemas.SnackNow.Api.Domain.Entities;
using DesSistemas.SnackNow.Api.Domain.Repositories.Interfaces;
using DesSistemas.SnackNow.Api.Dto.DonationRequests;
using DesSistemas.SnackNow.Startup.ApiLayers.Database;
using Microsoft.EntityFrameworkCore;

namespace DesSistemas.SnackNow.Api.Domain.Repositories
{
    public class DonationRequestRepository : RepositoryBase<DonationRequest, long, SnackNowApiContext>, IDonationRequestRepository
    {
        public DonationRequestRepository(SnackNowApiContext context) : base(context)
        {
        }

        public async Task<List<DonationRequestListDto>> GetAll()
        {
            using var context = new SnackNowApiContext();
            //return await context.Set<DonationRequest>().ToListAsync();

             var query = (from donation in context.DonationRequests
             from payment in context.Payments.Where(w => w.DonationRequestId == donation.Id && w.Status == Enums.PaymentStatus.Paid).DefaultIfEmpty()
             group payment by donation
             into groupResult
             select new DonationRequestListDto
             {
                 Id = groupResult.Key.Id,
                 AmountToRaise = groupResult.Key.AmountToRaise,
                 AnimalName = groupResult.Key.AnimalName,
                 Description = groupResult.Key.Description,
                 Total = groupResult.Sum(s => s.ValuePaid)
             });

            return await query.ToListAsync();
        }

        public async Task<DonationRequestImage?> GetByDonationRequestId(long requestId)
        {
            using var context = new SnackNowApiContext();
            return await context.Set<DonationRequestImage>().FirstOrDefaultAsync(f => f.DonationRequestId == requestId);
        }
    }
}