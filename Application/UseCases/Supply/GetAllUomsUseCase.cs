using Application.DTOs._01_Common;
using Application.DTOs.Supply;
using Application.Entities;
using Application.Factories;
using Application.Interfaces._01_Common;
using AutoMapper;

namespace Application.UseCases.Supply
{
    public class GetAllUomsUseCase
    {
        private readonly IGetAllByActiveRepo<UoMEntity> _getAllByActiveRepo;
        private readonly IMapper _mapper;

        public GetAllUomsUseCase(
            IGetAllByActiveRepo<UoMEntity> getAllByActiveRepo,
            IMapper mapper)
        {
            _getAllByActiveRepo = getAllByActiveRepo;
            _mapper = mapper;
        }

        public async Task<AppResult> Execute(bool isActive)
        {
            IEnumerable<UoMEntity>? listUomsEntity = await _getAllByActiveRepo.GetAllByActiveAsync(isActive);

            if (listUomsEntity == null)
                return ResultFactory.CreateNotFound("There are no units of measure");

            IEnumerable<GetUomOutput> listGetUomsOutput = listUomsEntity
                .Select(uomEntity => _mapper.Map<GetUomOutput>(uomEntity));

            return ResultFactory.CreateCreated("Units of mesure", listGetUomsOutput);
        }
    }
}
