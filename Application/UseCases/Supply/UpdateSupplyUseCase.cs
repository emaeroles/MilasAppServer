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
        private readonly IGetByIdRepo<SupplyEntity> _getByIdSupplyRepo;
        private readonly IGetByIdRepo<UoMEntity> _getByIdUomRepo;

        public UpdateSupplyUseCase(
            IUpdateRepo<SupplyEntity> updateRepo,
            IGetByIdRepo<SupplyEntity> getByIdSupplyRepo,
            IGetByIdRepo<UoMEntity> getByIdUomRepo)
        {
            _updateRepo = updateRepo;
            _getByIdSupplyRepo = getByIdSupplyRepo;
            _getByIdUomRepo = getByIdUomRepo;
        }

        public async Task<AppResult> Execute(UpdateSupplyInput updateSupplyInput)
        {
            UoMEntity? uomEntity = await _getByIdUomRepo.GetByIdAsync(updateSupplyInput.UoMId);
            if (uomEntity == null)
                return ResultFactory.CreateNotFound("The unit of measure was not found");

            SupplyEntity? supplyEntity = await _getByIdSupplyRepo.GetByIdAsync(updateSupplyInput.Id);

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
