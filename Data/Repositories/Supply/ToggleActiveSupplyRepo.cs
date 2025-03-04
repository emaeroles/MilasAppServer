using Application.Entities;
using Application.Interfaces._01_Common;
using Data.Context;

namespace Data.Repositories.Supply
{
    public class ToggleActiveSupplyRepo : IToggleActiveRepo<SupplyEntity>
    {
        private readonly AppDbContext _dbcontext;

        public ToggleActiveSupplyRepo(AppDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public async Task<bool> ToggleActiveAsync(int entityId)
        {
            var supplyModel = await _dbcontext.Supplies.FindAsync(entityId);

            if (supplyModel == null)
                return false;

            supplyModel.IsActive = !supplyModel.IsActive;

            int rows = await _dbcontext.SaveChangesAsync();

            if (rows == 0)
                return false;

            return true;
        }
    }
}
