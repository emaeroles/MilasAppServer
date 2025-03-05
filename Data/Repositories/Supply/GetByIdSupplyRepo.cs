using Application.Entities;
using Application.Interfaces._01_Common;
using Data.Context;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.Supply
{
    public class GetByIdSupplyRepo : IGetByIdRepo<SupplyEntity>
    {
        private readonly AppDbContext _dbcontext;

        public GetByIdSupplyRepo(AppDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public async Task<SupplyEntity?> GetByIdAsync(Guid entityId)
        {
            SupplyModel? supplyModel = await _dbcontext.Supplies
                .Include(s => s.Uom)
                .FirstOrDefaultAsync(s => s.Id == entityId);

            if (supplyModel == null)
                return null;

            return new SupplyEntity()
            {
                Id = supplyModel.Id,
                Name = supplyModel.Name,
                Quantity = supplyModel.Quantity,
                UoM = new UoMEntity()
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
