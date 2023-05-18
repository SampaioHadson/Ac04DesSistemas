using AutoMapper;
using DesSistemas.SnackNow.Api.Domain.Entities;
using DesSistemas.SnackNow.Api.Dto.Address;
using DesSistemas.SnackNow.Api.Dto.Bars;
using DesSistemas.SnackNow.Api.Dto.DonationRequests;
using DesSistemas.SnackNow.Api.Dto.Establishments;
using DesSistemas.SnackNow.Api.Dto.Product;

namespace DesSistemas.SnackNow.Api.Mappers
{
    public class EntityToDto : Profile
    {
        public EntityToDto() 
        {
            CreateMap<Address, AddressItemResponse>();
            CreateMap<Product, ProductItemResponse>();
            CreateMap<Establishment, EstablishmentItemResponse>();
            CreateMap<BarAddRequest, BarEntity>();
            CreateMap<BarEntity, BarListResponse>();
            CreateMap<DonationRequest, DonationRequestListDto>();
            //CreateMap(typeof(List<>), typeof(List<>))
            //    .ForMember("Item", map => map.Ignore()); 
        }
    }
}