﻿using DesSistemas.SnackNow.Api.Domain.Entities;
using DesSistemas.SnackNow.Startup.ApiLayers.Database;

namespace DesSistemas.SnackNow.Api.Domain.Repositories.Interfaces
{
    public interface IPaymentsRepository : IRepositoryBase<Payments, long>
    {
        Task<List<Payments>> GetAllToValidade();
    }
}