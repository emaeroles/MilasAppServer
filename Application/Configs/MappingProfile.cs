using Application.DTOs.User;
using Application.Entities;
using AutoMapper;

namespace Application.Configs
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // de product => a productGetDTO

            // Users
            CreateMap<UserEntity, GetUserOutput>();
            CreateMap<AddUserInput, UserEntity>();


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
