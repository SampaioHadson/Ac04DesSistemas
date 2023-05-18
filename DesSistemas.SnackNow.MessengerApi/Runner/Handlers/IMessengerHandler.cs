using DesSistemas.SnackNow.MessengerApi.Integration.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesSistemas.SnackNow.MessengerApi.Runner.Handlers
{
    public interface IMessengerHandler
    {
        Task<bool> HandleAsync(MessengerPaginateResponse<GetChatsResponse> chatsReponse, DateTime referenceDate);
    }
}