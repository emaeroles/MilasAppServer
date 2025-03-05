using Application.Entities;
using Application.Interfaces._01_Common;
using Data.Context;
using Data.Models;

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
            KioscoModel? kioscoModel = await _dbcontext.Kioscos.FindAsync(entity.Id);

            if (kioscoModel == null)
                throw new KeyNotFoundException($"No kiosco found with Id {entity.Id}.");

            kioscoModel.Name = entity.Name;
            kioscoModel.Manager = entity.Manager;
            kioscoModel.Phone = entity.Phone;
            kioscoModel.Address = entity.Address;
            kioscoModel.UserId = entity.UserId;
            kioscoModel.IsEnableChanges = entity.IsEnableChanges;
            kioscoModel.Notes = entity.Notes;
            kioscoModel.Dubt = entity.Dubt;
            kioscoModel.Order = entity.Order;
            kioscoModel.IsActive = entity.IsActive;

            int rows = await _dbcontext.SaveChangesAsync();

            if (rows == 0)
                return false;

            return true;
        }
    }
}
