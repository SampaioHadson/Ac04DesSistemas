using DesSistemas.SnackNow.Api.Domain.Entities;
using DesSistemas.SnackNow.Api.Domain.Repositories.Interfaces;
using DesSistemas.SnackNow.Api.Domain.Services.Interfaces;
using DesSistemas.SnackNow.Api.Dto.UserSystem;
using DesSistemas.SnackNow.Api.Integrations.AuthZero.Interfaces;
using DesSistemas.SnackNow.Startup.Exceptions;
using DesSistemas.SnackNow.Startup.Guard;

namespace DesSistemas.SnackNow.Api.Domain.Services
{
    public class CrudUserSystemService : ICrudUserSystemService
    {
        private readonly IUserSystemRepository _userSystemRepository;
        private readonly IAuthZeroIntegration _authZeroIntegration;

        public CrudUserSystemService(IUserSystemRepository userSystemRepository,
            IAuthZeroIntegration authZeroIntegration)
        {
            _userSystemRepository = userSystemRepository;
            _authZeroIntegration = authZeroIntegration;
        }

        public async Task<long> AddAsync(UserSystemAddRequest request)
        {
            Guard.NullOrEmpty(request.Password, () => new HttpBadRequestException("UserPassword é um campo obrigatório."));
            Guard.NullOrEmpty(request.Username, () => new HttpBadRequestException("UserName é um campo obrigatório."));
            Guard.NullOrEmpty(request.Cellphone, () => new HttpBadRequestException("Cellphone é um campo obrigatório."));
            Guard.NotExactlyLength(request.Cellphone, 11, () => new HttpBadRequestException("Cellphone é um campo de 11 dígitos."));
            await Guard.TrueAsync(_userSystemRepository.AnyWithUsernameAsync(request.Username), () => new HttpBadRequestException("Nome de usuário em uso."));

            var response = await _authZeroIntegration.SignUpAsync(request);
            var entity = new UserSystem(request, response.Id);
            return await _userSystemRepository.AddAsync(entity);
        }
    }
}