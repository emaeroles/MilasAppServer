using Application.DTOs.Kiosco;
using Application.DTOs.Product;
using Application.DTOs.Supply;
using Application.DTOs.User;
using Application.Entities;
using AutoMapper;

namespace Application.Configs
{
    internal class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // de => a

            // Users
            CreateMap<UserEntity, GetUserOutput>();
            CreateMap<AddUserInput, UserEntity>();
            CreateMap<UpdateUserInput, UserEntity>();

            // Kiosco
            CreateMap<KioscoEntity, GetKioscoOutput>();
            CreateMap<AddKioscoInput, KioscoEntity>();
            CreateMap<UpdateKioscoInput, KioscoEntity>();
            CreateMap<UpdateKioscoNotesInput, KioscoEntity>();
            CreateMap<UpdateKioscoDubtInput, KioscoEntity>();
            CreateMap<UpdateKioscoOrderInput, KioscoEntity>();

            // Suplies
            CreateMap<SupplyEntity, GetSupplyOutput>()
                .ForMember(dest => dest.UoM, opt => opt.MapFrom(src => src.UoM.Unit));
            CreateMap<AddSupplyInput, SupplyEntity>()
                .ForPath(dest => dest.UoM.Id, opt => opt.MapFrom(src => src.UoMId));
            CreateMap<UpdateSupplyInput, SupplyEntity>()
                .ForPath(dest => dest.UoM.Id, opt => opt.MapFrom(src => src.UoMId));

            CreateMap<UoMEntity, GetUomOutput>();
            CreateMap<AddUomInput, UoMEntity>();
            CreateMap<UpdateUomInput, UoMEntity>();

            // Products
            CreateMap<ProductEntity, GetProductOutput>();
            CreateMap<AddProductInput, ProductEntity>();

        }
    }
}
