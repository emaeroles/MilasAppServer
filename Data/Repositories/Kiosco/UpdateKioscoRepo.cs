using Application.Entities;
using Application.Interfaces._01_Common;
using Application.Interfaces.Kiosco;
using Data.Context;

namespace Data.Repositories.Kiosco
{
    public class UpdateKioscoRepo : IUpdateRepo<KioscoEntity>, IUpdateKioscoRepo<KioscoEntity>
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
        public async Task<bool> UpdateNotesAsync(KioscoEntity entity)
        {
            var kioscoModel = await _dbcontext.Kioscos.FindAsync(entity.Id);

            if (kioscoModel == null)
                return false;

            kioscoModel.Notes = entity.Notes;
            await _dbcontext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateDubtAsync(KioscoEntity entity)
        {
            var kioscoModel = await _dbcontext.Kioscos.FindAsync(entity.Id);

            if (kioscoModel == null)
                return false;

            kioscoModel.Dubt = entity.Dubt;
            await _dbcontext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateOrderAsync(KioscoEntity entity)
        {
            var kioscoModel = await _dbcontext.Kioscos.FindAsync(entity.Id);

            if (kioscoModel == null)
                return false;

            kioscoModel.Order = entity.Order;
            await _dbcontext.SaveChangesAsync();

            return true;
        }
    }
}
