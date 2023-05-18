using DesSistemas.SnackNow.Api.Domain.Entities;
using DesSistemas.SnackNow.Api.Domain.Helpers;
using DesSistemas.SnackNow.Api.Domain.Repositories.Interfaces;
using DesSistemas.SnackNow.Api.Domain.Services.Interfaces;
using DesSistemas.SnackNow.Api.Dto.UserSystemPassRecovery;
using DesSistemas.SnackNow.Api.Integrations.AuthZero.Dto;
using DesSistemas.SnackNow.Api.Integrations.AuthZero.Interfaces;
using DesSistemas.SnackNow.Startup.Exceptions;
using DesSistemas.SnackNow.Startup.Guard;
using DesSistemas.SnackNow.Twillo.Integration.Interfaces;

namespace DesSistemas.SnackNow.Api.Domain.Services
{
    public class PassRecoveryService : IPassRecoveryService
    {
        private readonly IUserSystemRepository _userSystemRepository;
        private readonly IUserSystemPassRecoveryRepository _userSystemPassRecoveryRepository;
        private readonly ITwilloIntegration _twilloIntegration;
        private readonly IAuthZeroIntegration _authZeroIntegration;
        private const string FaultMessageError = "Código inválido ou já utilizado.";

        public PassRecoveryService(IUserSystemRepository userSystemRepository,
            IUserSystemPassRecoveryRepository userSystemPassRecoveryRepository,
            ITwilloIntegration twilloIntegration,
            IAuthZeroIntegration authZeroIntegration)
        {
            _userSystemRepository = userSystemRepository;
            _userSystemPassRecoveryRepository = userSystemPassRecoveryRepository;
            _twilloIntegration = twilloIntegration;
            _authZeroIntegration = authZeroIntegration;
        }

        public async Task SendSmsToRecoveryAsync(string email)
        {
            var userSystem = await _userSystemRepository.GetByEmailAsync(email);
            if (userSystem == null)
                return;

            var userSystemId = userSystem.Id;
            var randomCode = RandomCodeHelper.GetRandomCode();
            var codeToVerify = RandomCodeHelper.GetVerifyRandomCode();
            var entity = new UserSystemPassRecovery(userSystemId, randomCode, codeToVerify);

            var message = $"SnackApi: Codigo - {randomCode}";
            var to = $"+55{userSystem.Cellphone}";
            await _twilloIntegration.SendSmsAsync(to, message);

            await _userSystemPassRecoveryRepository.AddAsync(entity);
        }

        public async Task<string> ConfirmSmsAsync(ConfirmSmsRequest confirm)
        {
            var userSystem = await _userSystemRepository.GetByEmailAsync(confirm.Email);
            Guard.Null(userSystem, () => new HttpBadRequestException(FaultMessageError));

            var passRecovery = await _userSystemPassRecoveryRepository.GetByCodeAsync(confirm.Code);
            Guard.Null(passRecovery, () => new HttpBadRequestException(FaultMessageError));

            passRecovery!.Status = Enums.UserSystemPassRecoveryStatus.Confirmed;
            await _userSystemPassRecoveryRepository.UpdateAsync(passRecovery);
            return passRecovery.CodeToVerify;
        }

        public async Task ChangePasswordAsync(ChangePasswordRequest change)
        {
            var passRecovery = await _userSystemPassRecoveryRepository.GetByRandomCodeAndVerifyCodeAsync(change.RandomCode, change.CodeVerify);
            Guard.Null(passRecovery, () => new HttpBadRequestException(FaultMessageError));
            if (passRecovery.Status == Enums.UserSystemPassRecoveryStatus.Finished)
                throw new HttpBadRequestException(FaultMessageError);
            
            if (change.Password != change.RepeatPassword)
                throw new HttpBadRequestException("Senha e confirmação não conferem.");

            var userSystem = await _userSystemRepository.GetByIdAsync(passRecovery!.UserSystemId);
            Guard.Null(userSystem, () => new HttpBadRequestException(FaultMessageError));

            var authZeroId = userSystem!.AuthZeroId;
            var request = new AuthZeroChangePassInternalRequest(authZeroId, change.Password);
            await _authZeroIntegration.ChangePasswordAsync(request);

            passRecovery.Status = Enums.UserSystemPassRecoveryStatus.Finished;
            await _userSystemPassRecoveryRepository.UpdateAsync(passRecovery);
        }
    }
}