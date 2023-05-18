using DesSistemas.SnackNow.Api.Domain.Context;
using DesSistemas.SnackNow.Api.Domain.Entities;
using DesSistemas.SnackNow.Api.Domain.Repositories.Interfaces;
using DesSistemas.SnackNow.Startup.ApiLayers.Database;
using Microsoft.EntityFrameworkCore;

namespace DesSistemas.SnackNow.Api.Domain.Repositories
{
    public class MessengerMessageRepository : RepositoryBase<MessengerMessage, long, SnackNowApiContext>, IMessengerMessageRepository
    {
        public MessengerMessageRepository(SnackNowApiContext context) : base(context)
        {
        }

        public async Task<bool> HasAnyWithId(string id)
        {
            return await _context.MessengerMessages.AnyAsync(a => a.MessageId == id);
        }
    }
}