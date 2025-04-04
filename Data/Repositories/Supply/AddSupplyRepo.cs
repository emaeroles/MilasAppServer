﻿using Application.Entities;
using Application.Interfaces._01_Common;
using Data.Context;
using Data.Models;

namespace Data.Repositories.Supply
{
    public class AddSupplyRepo : IAddRepo<SupplyEntity>
    {
        private readonly AppDbContext _dbContext;

        public AddSupplyRepo(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> AddAsync(SupplyEntity entity)
        {
            SupplyModel supplyModel = new SupplyModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                Quantity = entity.Quantity,
                UomId = entity.Uom.Id,
                CostPrice = entity.CostPrice,
                Yeild = entity.Yeild,
                IsActive = entity.IsActive,
            };

            _dbContext.Supplies.Add(supplyModel);
            int rows = await _dbContext.SaveChangesAsync();

            if (rows == 0)
                return false;

            return true;
        }
    }
}
