using Application.Entities;
using Application.Interfaces._01_Common;
using Data.Context;
using Data.Models;

namespace Data.Repositories.Kiosco
{
    public class AddKioscoRepo : IAddRepo<KioscoEntity>
    {
        private readonly AppDbContext _dbContext;

        public AddKioscoRepo(AppDbContext dbContext)
        {
            _dbContext = dbContext;
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

            _dbContext.Kioscos.Add(kioscoModel);
            int rows = await _dbContext.SaveChangesAsync();

            if(rows == 0)
                return false;

            return true;
        }
    }
}
