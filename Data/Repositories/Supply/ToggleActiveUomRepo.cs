using Application.Entities;
using Application.Interfaces._01_Common;
using Data.Context;

namespace Data.Repositories.Supply
{
    public class ToggleActiveUomRepo : IToggleActiveRepo<UoMEntity>
    {
        private readonly AppDbContext _dbcontext;

        public ToggleActiveUomRepo(AppDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public async Task<bool> ToggleActiveAsync(int entityId)
        {
            var uomModel = await _dbcontext.Uoms.FindAsync(entityId);

            if (uomModel == null)
                return false;

            uomModel.IsActive = !uomModel.IsActive;

            int rows = await _dbcontext.SaveChangesAsync();

            if (rows == 0)
                return false;

            return true;
        }
    }
}
