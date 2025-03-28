﻿using Application.Entities;
using Application.Interfaces._01_Common;
using Data.Context;
using Data.Models;

namespace Data.Repositories.Supply
{
    public class UpdateSupplyRepo : IUpdateRepo<SupplyEntity>
    {
        private readonly AppDbContext _dbContext;

        public UpdateSupplyRepo(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> UpdateAsync(SupplyEntity entity)
        {
            SupplyModel? supplyModel = await _dbContext.Supplies.FindAsync(entity.Id);

            if (supplyModel == null)
                throw new KeyNotFoundException($"No supply found with Id {entity.Id}.");

            supplyModel.Name = entity.Name;
            supplyModel.Quantity = entity.Quantity;
            supplyModel.UomId = entity.Uom.Id;
            supplyModel.CostPrice = entity.CostPrice;
            supplyModel.Yeild = entity.Yeild;
            supplyModel.IsActive = entity.IsActive;

            int rows = await _dbContext.SaveChangesAsync();

            if (rows == 0)
                return false;

            return true;
        }
    }
}
