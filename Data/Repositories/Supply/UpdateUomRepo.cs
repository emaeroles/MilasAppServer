using Application.Entities;
using Application.Interfaces._01_Common;
using Data.Context;
using Data.Models;

namespace Data.Repositories.Supply
{
    public class UpdateUomRepo : IUpdateRepo<UomEntity>
    {
        private readonly AppDbContext _dbcontext;

        public UpdateUomRepo(AppDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public async Task<bool> UpdateAsync(UomEntity entity)
        {
            UomModel? uomModel = await _dbcontext.Uoms.FindAsync(entity.Id);

            if (uomModel == null)
                throw new KeyNotFoundException($"No unit of measure found with Id {entity.Id}.");

            uomModel.Unit = entity.Unit;
            uomModel.IsActive = entity.IsActive;

            int rows = await _dbcontext.SaveChangesAsync();

            if (rows == 0)
                return false;

            return true;
        }
    }
}
