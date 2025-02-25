using Application.Interfaces._01_Common;
using Data.Context;

namespace Data.Repositories.Kiosco
{
    public class ToggleActiveKioscoRepo : IToggleActiveRepo
    {
        private readonly AppDbContext _dbcontext;

        public ToggleActiveKioscoRepo(AppDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public async Task<bool> ToggleActiveAsync(int entityId)
        {
            var kioscoModel = await _dbcontext.Kioscos.FindAsync(entityId);

            if (kioscoModel == null)
                return false;

            kioscoModel.IsActive = !kioscoModel.IsActive;
            await _dbcontext.SaveChangesAsync();

            return true;
        }
    }
}
