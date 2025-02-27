using Application.DTOs._01_Common;
using Application.DTOs.Supply;
using Application.Entities;
using Application.Factories;
using Application.Interfaces._01_Common;
using AutoMapper;

namespace Application.UseCases.Supply
{
    public class GetAllSuppliesUseCase
    {
        private readonly IGetAllByActiveRepo<SupplyEntity> _getAllByActiveRepo;
        private readonly IMapper _mapper;

        public GetAllSuppliesUseCase(
            IGetAllByActiveRepo<SupplyEntity> getAllByActiveRepo,
            IMapper mapper)
        {
            _getAllByActiveRepo = getAllByActiveRepo;
            _mapper = mapper;
        }

        public async Task<AppResult> Execute(bool isActive)
        {
            var listSuppliesEntity = await _getAllByActiveRepo.GetAllByActiveAsync(isActive);
            var listGetSuppliesOutput = listSuppliesEntity
                .Select(supplyEntity => _mapper.Map<GetSupplyOutput>(supplyEntity));

            return ResultFactory.CreateSuccess("Sipplies", listGetSuppliesOutput);
        }
    }
}
