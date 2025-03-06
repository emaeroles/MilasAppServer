using Application.DTOs._01_Common;
using Application.DTOs.Supply;
using Application.Entities;
using Application.Factories;
using Application.Interfaces._01_Common;

namespace Application.UseCases.Supply
{
    public class UpdateSupplyUseCase
    {
        private readonly IUpdateRepo<SupplyEntity> _updateRepo;
        private readonly IGetByIdRepo<SupplyEntity> _getByIdRepo;

        public UpdateSupplyUseCase(
            IUpdateRepo<SupplyEntity> updateRepo,
            IGetByIdRepo<SupplyEntity> getByIdRepo)
        {
            _updateRepo = updateRepo;
            _getByIdRepo = getByIdRepo;
        }

        public async Task<AppResult> Execute(UpdateSupplyInput updateSupplyInput)
        {
            SupplyEntity? supplyEntity = await _getByIdRepo.GetByIdAsync(updateSupplyInput.Id);

            if (supplyEntity == null)
                return ResultFactory.CreateNotFound("The supply does not exist");

            supplyEntity.Name = updateSupplyInput.Name;
            supplyEntity.Quantity = updateSupplyInput.Quantity;
            supplyEntity.UoM.Id = updateSupplyInput.UoMId;
            supplyEntity.CostPrice = updateSupplyInput.CostPrice;
            supplyEntity.Yeild = updateSupplyInput.Yeild;

            var isUpdated = await _updateRepo.UpdateAsync(supplyEntity);
            if (!isUpdated)
                return ResultFactory.CreateNotUpdated("The supply was not updated");

            return ResultFactory.CreateUpdated("The supply was updated");
        }
    }
}
