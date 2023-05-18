using DesSistemas.SnackNow.Api.Domain.Entities;
using DesSistemas.SnackNow.Api.Domain.Repositories.Interfaces;
using DesSistemas.SnackNow.Api.Domain.Services.Interfaces;
using DesSistemas.SnackNow.Api.Integrations.ViaCep.Interfaces;
using DesSistemas.SnackNow.Startup.Exceptions;
using DesSistemas.SnackNow.Startup.Guard;

namespace DesSistemas.SnackNow.Api.Domain.Services
{
    public class AddressSearchService : IAddressSearchService
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IViaCepIntegration _viaCepIntegration;

        public AddressSearchService(IAddressRepository addressRepository,
            IViaCepIntegration viaCepIntegration)
        {
            _addressRepository = addressRepository;
            _viaCepIntegration = viaCepIntegration;
        }

        public async Task<Address> GetByPostalCodeAsync(string postalCode)
        {
            Guard.NotExactlyLength(postalCode, 8, () => new HttpBadRequestException("O campo PostalCode deve conter 8 caracteres numéricos."));
            var entity = await _addressRepository.GetByPostalCodeAsync(postalCode);
            if (entity != null)
                return entity;

            var viaCepAddress = await _viaCepIntegration.GetByPostalCode(postalCode);

            var address = new Address(viaCepAddress, postalCode);
            await _addressRepository.AddAsync(address);

            return address;
        }
    }
}