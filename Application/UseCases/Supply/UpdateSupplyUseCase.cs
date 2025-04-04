﻿using Application.DTOs._01_Common;
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
        private readonly IGetByIdRepo<UomEntity> _getByIdUomRepo;

        public UpdateSupplyUseCase(
            IUpdateRepo<SupplyEntity> updateRepo,
            IGetByIdRepo<SupplyEntity> getByIdSupplyRepo,
            IGetByIdRepo<UomEntity> getByIdUomRepo)
        {
            _updateRepo = updateRepo;
            _getByIdSupplyRepo = getByIdSupplyRepo;
            _getByIdUomRepo = getByIdUomRepo;
        }

        public async Task<AppResult> Execute(UpdateSupplyInput updateSupplyInput)
        {
            UomEntity? uomEntity = await _getByIdUomRepo.GetByIdAsync(updateSupplyInput.UomId);
            if (uomEntity == null)
                return ResultFactory.CreateNotFound("The unit of measure was not found");

            SupplyEntity? supplyEntity = await _getByIdSupplyRepo.GetByIdAsync(updateSupplyInput.Id);

            if (supplyEntity == null)
                return ResultFactory.CreateNotFound("The supply does not exist");

            supplyEntity.Name = updateSupplyInput.Name;
            supplyEntity.Quantity = updateSupplyInput.Quantity;
            supplyEntity.Uom.Id = updateSupplyInput.UomId;
            supplyEntity.CostPrice = updateSupplyInput.CostPrice;
            supplyEntity.Yeild = updateSupplyInput.Yeild;

            var isUpdated = await _updateRepo.UpdateAsync(supplyEntity);
            if (!isUpdated)
                return ResultFactory.CreateNotUpdated("The supply was not updated");

            return ResultFactory.CreateUpdated("The supply was updated");
        }
    }
}
