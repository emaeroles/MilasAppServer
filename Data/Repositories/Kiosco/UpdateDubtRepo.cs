using Application.Entities;
using Application.Interfaces._01_Common;
using Data.Context;

namespace Data.Repositories.Kiosco
{
    public class UpdateDubtRepo : IUpdateRepo<KioscoEntity>
    {
        private readonly AppDbContext _dbcontext;

        public UpdateDubtRepo(AppDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public async Task<bool> UpdateAsync(KioscoEntity entity)
        {
            var kioscoModel = await _dbcontext.Kioscos.FindAsync(entity.Id);

            if (kioscoModel == null)
                return false;

            kioscoModel.Dubt = entity.Dubt;
            await _dbcontext.SaveChangesAsync();

            return true;
        }
    }
}
