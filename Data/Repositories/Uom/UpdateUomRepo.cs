using Application.Entities;
using Application.Interfaces._01_Common;
using Data.Context;
using Data.Models;

namespace Data.Repositories.Uom
{
    public class UpdateUomRepo : IUpdateRepo<UomEntity>
    {
        private readonly AppDbContext _dbContext;

        public UpdateUomRepo(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> UpdateAsync(UomEntity entity)
        {
            UomModel? uomModel = await _dbContext.Uoms.FindAsync(entity.Id);

            if (uomModel == null)
                throw new KeyNotFoundException($"No unit of measure found with Id {entity.Id}.");

            uomModel.Unit = entity.Unit;
            uomModel.IsActive = entity.IsActive;

            int rows = await _dbContext.SaveChangesAsync();

            if (rows == 0)
                return false;

            return true;
        }
    }
}
