using Application.DTOs._01_Common;
using Application.DTOs.User;
using Application.Entities;
using Application.Factories;
using Application.Interfaces._01_Common;
using AutoMapper;

namespace Application.UseCases.Kiosco
{
    public class GetAllKioscosUseCase
    {
        private readonly IGetAllByActiveRepo<KioscoEntity> _getAllByActiveRepo;
        private readonly IMapper _mapper;

        public GetAllKioscosUseCase(
            IGetAllByActiveRepo<KioscoEntity> getAllByActiveRepo,
            IMapper mapper)
        {
            _getAllByActiveRepo = getAllByActiveRepo;
            _mapper = mapper;
        }

        public async Task<AppResult> Execute(bool isActive)
        {
            var listKioscosEntity = await _getAllByActiveRepo.GetAllByActiveAsync(isActive);
            var listGetKioscosOutput = listKioscosEntity
                .Select(kioscoEntity => _mapper.Map<GetUserOutput>(kioscoEntity));

            return ResultFactory.CreateSuccess("Users", listGetKioscosOutput);
        }
    }
}
