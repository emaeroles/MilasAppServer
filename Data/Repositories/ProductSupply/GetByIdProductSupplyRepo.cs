﻿using Application.Entities;
using Application.Interfaces._01_Common;
using Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.ProductSupply
{
    public class GetByIdProductSupplyRepo : IGetByIdComposedRepo<ProductSupplyEntity>
    {
        private readonly AppDbContext _dbcontext;

        public GetByIdProductSupplyRepo(AppDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public async Task<ProductSupplyEntity?> GetByIdComposedAsync(Guid entityId, Guid byEntityId)
        {
            IQueryable<ProductSupplyEntity> queryProductSupply = _dbcontext.Supplies
                .Where(s => s.Id == entityId && s.Products.Any(p => p.Id == byEntityId))
                .Include(s => s.Uom)
                .Where(s => s.IsActive)
                .Select(s => new ProductSupplyEntity
                {
                    Id = s.Id,
                    SupplyId = s.Id,
                    ProductId = s.Id,
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
                });

            ProductSupplyEntity? productSupplyEntity = await queryProductSupply.FirstOrDefaultAsync();

            if (productSupplyEntity == null)
                return null;

            return productSupplyEntity;
        }
    }
}
