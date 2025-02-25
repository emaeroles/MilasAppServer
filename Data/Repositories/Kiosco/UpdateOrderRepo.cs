using Application.Entities;
using Application.Interfaces._01_Common;
using Data.Context;

namespace Data.Repositories.Kiosco
{
    public class UpdateOrderRepo : IUpdateRepo<KioscoEntity>
    {
        private readonly AppDbContext _dbcontext;

        public UpdateOrderRepo(AppDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public async Task<bool> UpdateAsync(KioscoEntity entity)
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
