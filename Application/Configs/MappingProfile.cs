﻿using Application.DTOs.Kiosco;
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

            //// Supplies Product
            //CreateMap<SuplyProductAddDTO, Product>()
            //    .ForPath(dest => dest.Id, opt => opt.MapFrom(src => src.ProductId))
            //    .AfterMap((src, dest) =>
            //    {
            //        dest.Supplies = new Supply[]
            //        {
            //            new Supply { Id = src.SupplyId }
            //        };
            //    });

            //// Supply
            //CreateMap<Supply, SupplyGetDTO>()
            //    .ForMember(dest => dest.UoM, opt => opt.MapFrom(src => src.UoM.Unit));
            //CreateMap<SupplyAddDTO, Supply>()
            //    .ForPath(dest => dest.UoM.Id, opt => opt.MapFrom(src => src.UoMId));
            //CreateMap<SupplyUpdateDTO, Supply>()
            //    .ForPath(dest => dest.UoM.Id, opt => opt.MapFrom(src => src.UoMId));

        }
    }
}
