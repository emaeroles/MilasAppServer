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

        public async Task<int> AddAsync(KioscoEntity entity)
        {
            var kioscoModel = new KioscoModel()
            {
                Name = entity.Name,
                Manager = entity.Manager,
                Phone = entity.Phone,
                Address = entity.Address,
                UserId = entity.UserId,
                IsEnableChanges = false,
                Notes = string.Empty,
                Dubt = 0,
                Order = 0,
                IsActive = true,
            };

            _dbcontext.Kioscos.Add(kioscoModel);
            int rows = await _dbcontext.SaveChangesAsync();

            return kioscoModel.Id;
        }
    }
}
