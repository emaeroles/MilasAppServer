using Application.DTOs._01_Common;
using Application.DTOs.Kiosco;
using Application.Entities;
using Application.Factories;
using Application.Interfaces._01_Common;
using AutoMapper;

namespace Application.UseCases.Kiosco
{
    public class GetAllKioscosUseCase
    {
        private readonly IGetAllByActiveAndUserRepo _getAllByActiveAndUserRepo;
        private readonly IMapper _mapper;

        public GetAllKioscosUseCase(
            IGetAllByActiveAndUserRepo getAllByActiveAndUserRepo,
            IMapper mapper)
        {
            _getAllByActiveAndUserRepo = getAllByActiveAndUserRepo;
            _mapper = mapper;
        }

        public async Task<AppResult> Execute(bool isActive, Guid userId)
        {
            IEnumerable<KioscoEntity>? listKioscosEntity = await _getAllByActiveAndUserRepo
                .GetAllByActiveAndUserAsync(isActive, userId);

            if (listKioscosEntity == null)
                return ResultFactory.CreateNotFound("There are no kioscos");

            IEnumerable<GetKioscoOutput> listGetKioscosOutput = listKioscosEntity
                .Select(kioscoEntity => _mapper.Map<GetKioscoOutput>(kioscoEntity));

            return ResultFactory.CreateData("Kioscos", listGetKioscosOutput);
        }
    }
}
