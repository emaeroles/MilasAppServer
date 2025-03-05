using Application.Entities;
using Application.Interfaces._01_Common;
using Data.Context;
using Data.Models;

namespace Data.Repositories.Kiosco
{
    public class AddKioscoRepo : IAddRepo<KioscoEntity>
    {
        private readonly AppDbContext _dbcontext;

        public AddKioscoRepo(AppDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public async Task<bool> AddAsync(KioscoEntity entity)
        {
            KioscoModel kioscoModel = new KioscoModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                Manager = entity.Manager,
                Phone = entity.Phone,
                Address = entity.Address,
                UserId = entity.UserId,
                IsEnableChanges = entity.IsEnableChanges,
                Notes = entity.Notes,
                Dubt = entity.Dubt,
                Order = entity.Order,
                IsActive = entity.IsActive,
            };

            _dbcontext.Kioscos.Add(kioscoModel);
            int rows = await _dbcontext.SaveChangesAsync();

            if(rows == 0)
                return false;

            return true;
        }
    }
}
