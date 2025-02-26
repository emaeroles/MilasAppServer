using Application.DTOs._01_Common;
using Application.DTOs.Supply;
using Application.Entities;
using Application.Factories;
using Application.Interfaces._01_Common;
using AutoMapper;

namespace Application.UseCases.Supply
{
    public class GetAllUomUseCase
    {
        private readonly IGetAllByActiveRepo<UoMEntity> _getAllByActiveRepo;
        private readonly IMapper _mapper;

        public GetAllUomUseCase(
            IGetAllByActiveRepo<UoMEntity> getAllByActiveRepo,
            IMapper mapper)
        {
            _getAllByActiveRepo = getAllByActiveRepo;
            _mapper = mapper;
        }

        public async Task<AppResult> Execute(bool isActive)
        {
            var listUomsEntity = await _getAllByActiveRepo.GetAllByActiveAsync(isActive);
            var listGetUomsOutput = listUomsEntity
                .Select(uomEntity => _mapper.Map<GetUomOutput>(uomEntity));

            return ResultFactory.CreateSuccess("Units of Mesure", listGetUomsOutput);
        }
    }
}
