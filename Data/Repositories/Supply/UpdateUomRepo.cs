using Application.Entities;
using Application.Interfaces._01_Common;
using Data.Context;

namespace Data.Repositories.Supply
{
    public class UpdateUomRepo : IUpdateRepo<UoMEntity>
    {
        private readonly AppDbContext _dbcontext;

        public UpdateUomRepo(AppDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public async Task<bool> UpdateAsync(UoMEntity entity)
        {
            var uomModel = await _dbcontext.Uoms.FindAsync(entity.Id);

            if (uomModel == null)
                return false;

            uomModel.Unit = entity.Unit;

            int rows = await _dbcontext.SaveChangesAsync();

            if (rows == 0)
                return false;

            return true;
        }
    }
}
