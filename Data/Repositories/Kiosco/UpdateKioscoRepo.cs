using Application.Entities;
using Application.Interfaces._01_Common;
using Data.Context;

namespace Data.Repositories.Kiosco
{
    public class UpdateKioscoRepo : IUpdateRepo<KioscoEntity>
    {
        private readonly AppDbContext _dbcontext;

        public UpdateKioscoRepo(AppDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public async Task<bool> UpdateAsync(KioscoEntity entity)
        {
            var kioscoModel = await _dbcontext.Kioscos.FindAsync(entity.Id);

            if (kioscoModel == null)
                return false;

            kioscoModel.Name = entity.Name;
            kioscoModel.Manager = entity.Manager;
            kioscoModel.Phone = entity.Phone;
            kioscoModel.Address = entity.Address;
            kioscoModel.UserId = entity.UserId;
            await _dbcontext.SaveChangesAsync();

            return true;
        }
    }
}
