using DesSistemas.SnackNow.Api.Domain.Context;
using DesSistemas.SnackNow.Api.Domain.Entities;
using DesSistemas.SnackNow.Api.Domain.Repositories.Interfaces;
using DesSistemas.SnackNow.Startup.ApiLayers.Database;
using Microsoft.EntityFrameworkCore;

namespace DesSistemas.SnackNow.Api.Domain.Repositories
{
    public class PaymentsRepository : RepositoryBase<Payments, long, SnackNowApiContext>, IPaymentsRepository
    {
        public PaymentsRepository(SnackNowApiContext context) : base(context)
        {
        }

        public async Task<List<Payments>> GetAllToValidade()
        {
            using var context = new SnackNowApiContext();
            return await context.Payments
                .AsNoTracking()
                .Where(w => w.Status == Enums.PaymentStatus.Pending)
                .ToListAsync();
        }
    }
}