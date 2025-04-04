﻿using Application.Entities;
using Application.Interfaces._01_Common;
using Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.Supply
{
    public class GetAllSuppliesRepo : IGetAllByActiveRepo<SupplyEntity>
    {
        private readonly AppDbContext _dbContext;

        public GetAllSuppliesRepo(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<SupplyEntity>?> GetAllByActiveAsync(bool isActive)
        {
            IQueryable<SupplyEntity> querySupply = _dbContext.Supplies
                .Where(s => s.IsActive == isActive)
                .Select(s => new SupplyEntity
                {
                    Id = s.Id,
                    Name = s.Name,
                    Quantity = s.Quantity,
                    Uom = new UomEntity()
                    {
                        Id = s.Uom.Id,
                        Unit = s.Uom.Unit,
                        IsActive = s.Uom.IsActive
                    },
                    CostPrice = s.CostPrice,
                    Yeild = s.Yeild,
                    IsActive = s.IsActive
                });

            IEnumerable<SupplyEntity> listSupplyEntity = await querySupply.ToListAsync();

            if (!listSupplyEntity.Any())
                return null;

            return listSupplyEntity;
        }
    }
}
