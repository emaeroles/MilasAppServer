using Application.DTOs._01_Common;
using Application.Entities;
using Application.Factories;
using Application.Interfaces._01_Common;

namespace Application.UseCases.Supply
{
    public class ToggleActiveSupplyUseCase
    {
        private readonly IUpdateRepo<SupplyEntity> _updateRepo;
        private readonly IGetByIdRepo<SupplyEntity> _getByIdRepo;

        public ToggleActiveSupplyUseCase(
            IUpdateRepo<SupplyEntity> updateRepo,
            IGetByIdRepo<SupplyEntity> getByIdRepo)
        {
            _updateRepo = updateRepo;
            _getByIdRepo = getByIdRepo;
        }

        public async Task<AppResult> Execute(Guid id)
        {
            SupplyEntity? supplyEntity = await _getByIdRepo.GetByIdAsync(id);

            if (supplyEntity == null)
                return ResultFactory.CreateNotFound("The supply does not exist");

            supplyEntity.IsActive = !supplyEntity.IsActive;

            var isUpdated = await _updateRepo.UpdateAsync(supplyEntity);
            if (!isUpdated)
                return ResultFactory.CreateNotUpdated("Supply activation was not changed");

            return ResultFactory.CreateUpdated("Supply activation was changed");
        }
    }
}
