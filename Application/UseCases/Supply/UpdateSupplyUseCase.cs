using Application.DTOs._01_Common;
using Application.DTOs.Supply;
using Application.Entities;
using Application.Factories;
using Application.Interfaces._01_Common;
using AutoMapper;

namespace Application.UseCases.Supply
{
    public class UpdateSupplyUseCase
    {
        private readonly IUpdateRepo<SupplyEntity> _updateRepo;
        private readonly IMapper _mapper;

        public UpdateSupplyUseCase(
            IUpdateRepo<SupplyEntity> updateRepo,
            IMapper mapper)
        {
            _updateRepo = updateRepo;
            _mapper = mapper;
        }

        public async Task<AppResult> Execute(UpdateSupplyInput updateSupplyInput)
        {
            var supplyEntity = _mapper.Map<SupplyEntity>(updateSupplyInput);

            var isOk = await _updateRepo.UpdateAsync(supplyEntity);
            if (!isOk)
                return ResultFactory.CreateNotFound($"Supply was not updated, " +
                    $"id {updateSupplyInput.Id} does not exist");

            return ResultFactory.CreateSuccess("Supply was updated", null);
        }
    }
}
