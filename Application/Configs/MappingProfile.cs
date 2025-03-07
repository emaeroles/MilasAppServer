using Application.DTOs.Kiosco;
using Application.DTOs.Product;
using Application.DTOs.ProductKiosco;
using Application.DTOs.Supply;
using Application.DTOs.SupplyProduct;
using Application.DTOs.Uom;
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

            // Kiosco
            CreateMap<KioscoEntity, GetKioscoOutput>();
            CreateMap<AddKioscoInput, KioscoEntity>();
            CreateMap<UpdateKioscoInput, KioscoEntity>();
            CreateMap<UpdateKioscoNotesInput, KioscoEntity>();
            CreateMap<UpdateKioscoDubtInput, KioscoEntity>();
            CreateMap<UpdateKioscoOrderInput, KioscoEntity>();

            // Products
            CreateMap<ProductEntity, GetProductOutput>();
            CreateMap<AddProductInput, ProductEntity>();
            CreateMap<UpdateProductInput, ProductEntity>();

            // ProductKiosco
            CreateMap<AddProductKioscoInput, ProductKioscoEntity>();

            // Supplies
            CreateMap<SupplyEntity, GetSupplyOutput>()
                .ForMember(dest => dest.Uom, opt => opt.MapFrom(src => src.Uom.Unit));
            CreateMap<AddSupplyInput, SupplyEntity>()
                .ForPath(dest => dest.Uom.Id, opt => opt.MapFrom(src => src.UomId));
            CreateMap<UpdateSupplyInput, SupplyEntity>()
                .ForPath(dest => dest.Uom.Id, opt => opt.MapFrom(src => src.UomId));

            // SupplyProduct
            CreateMap<SupplyProductEntity, GetSupplyOutput>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.SupplyId))
                .ForMember(dest => dest.Uom, opt => opt.MapFrom(src => src.Uom.Unit));
            CreateMap<AddSupplyProductInput, SupplyProductEntity>();

            // Uom
            CreateMap<UomEntity, GetUomOutput>();
            CreateMap<AddUomInput, UomEntity>();
            CreateMap<UpdateUomInput, UomEntity>();

            // Users
            CreateMap<UserEntity, GetUserOutput>();
            CreateMap<AddUserInput, UserEntity>();
            CreateMap<UpdateUserInput, UserEntity>();
        }
    }
}
