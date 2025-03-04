using Application.Entities;
using Application.Interfaces._01_Common;
using Data.Context;

namespace Data.Repositories.Supply
{
    public class UpdateSupplyRepo : IUpdateRepo<SupplyEntity>
    {
        private readonly AppDbContext _dbcontext;

        public UpdateSupplyRepo(AppDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public async Task<bool> UpdateAsync(SupplyEntity entity)
        {
            var supplyModel = await _dbcontext.Supplies.FindAsync(entity.Id);

            if (supplyModel == null)
                return false;

            supplyModel.Name = entity.Name;
            supplyModel.Quantity = entity.Quantity;
            supplyModel.UomId = entity.Id;
            supplyModel.CostPrice = entity.CostPrice;
            supplyModel.Yeild = entity.Yeild;

            int rows = await _dbcontext.SaveChangesAsync();

            if (rows == 0)
                return false;

            return true;
        }
    }
}
