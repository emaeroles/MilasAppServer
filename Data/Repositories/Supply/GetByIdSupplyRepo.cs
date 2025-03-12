using Application.Entities;
using Application.Interfaces._01_Common;
using Data.Context;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.Supply
{
    public class GetByIdSupplyRepo : IGetByIdRepo<SupplyEntity>
    {
        private readonly AppDbContext _dbContext;

        public GetByIdSupplyRepo(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<SupplyEntity?> GetByIdAsync(Guid entityId)
        {
            SupplyModel? supplyModel = await _dbContext.Supplies
                .Include(s => s.Uom)
                .FirstOrDefaultAsync(s => s.Id == entityId);

            if (supplyModel == null)
                return null;

            return new SupplyEntity()
            {
                Id = supplyModel.Id,
                Name = supplyModel.Name,
                Quantity = supplyModel.Quantity,
                Uom = new UomEntity()
                {
                    Id = supplyModel.Uom.Id,
                    Unit = supplyModel.Uom.Unit,
                    IsActive = supplyModel.Uom.IsActive
                },
                CostPrice = supplyModel.CostPrice,
                Yeild = supplyModel.Yeild,
                IsActive = supplyModel.IsActive
            };
        }
    }
}
