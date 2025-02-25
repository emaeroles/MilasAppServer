using Application.Entities;
using Application.Interfaces._01_Common;
using Data.Context;

namespace Data.Repositories.Kiosco
{
    public class UpdateNotesRepo : IUpdateRepo<KioscoEntity>
    {
        private readonly AppDbContext _dbcontext;

        public UpdateNotesRepo(AppDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public async Task<bool> UpdateAsync(KioscoEntity entity)
        {
            var kioscoModel = await _dbcontext.Kioscos.FindAsync(entity.Id);

            if (kioscoModel == null)
                return false;

            kioscoModel.Notes = entity.Notes;
            await _dbcontext.SaveChangesAsync();

            return true;
        }
    }
}
