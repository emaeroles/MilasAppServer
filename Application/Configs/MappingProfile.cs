using Application.DTOs.Kiosco;
using Application.DTOs.KioscoProduct;
using Application.DTOs.Product;
using Application.DTOs.ProductSupply;
using Application.DTOs.Supply;
using Application.DTOs.Uom;
using Application.DTOs.User;
using Application.DTOs.Visit;
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

            // Product
            CreateMap<ProductEntity, GetProductOutput>();
            CreateMap<AddProductInput, ProductEntity>();
            CreateMap<UpdateProductInput, ProductEntity>();

            // ProductKiosco
            CreateMap<KioscoProductEntity, GetKioscoProductOutput>();
            CreateMap<AddKioscoProductInput, KioscoProductEntity>();

            // Supply
            CreateMap<SupplyEntity, GetSupplyOutput>()
                .ForMember(dest => dest.UomId, opt => opt.MapFrom(src => src.Uom.Id));
            CreateMap<AddSupplyInput, SupplyEntity>()
                .ForPath(dest => dest.Uom.Id, opt => opt.MapFrom(src => src.UomId));
            CreateMap<UpdateSupplyInput, SupplyEntity>()
                .ForPath(dest => dest.Uom.Id, opt => opt.MapFrom(src => src.UomId));

            // SupplyProduct
            CreateMap<ProductSupplyEntity, GetSupplyOutput>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.SupplyId))
                .ForMember(dest => dest.UomId, opt => opt.MapFrom(src => src.Uom.Id));
            CreateMap<AddProductSupplyInput, ProductSupplyEntity>();

            // Uom
            CreateMap<UomEntity, GetUomOutput>();
            CreateMap<AddUomInput, UomEntity>();
            CreateMap<UpdateUomInput, UomEntity>();

            // User
            CreateMap<UserEntity, GetUserOutput>();
            CreateMap<AddUserInput, UserEntity>();
            CreateMap<UpdateUserInput, UserEntity>();

            // Visit
            CreateMap<VisitEntity, GetVisitOutput>();
            CreateMap<VisitDetailEntity, GetVisitDetailOutput>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name));
        }
    }
}
