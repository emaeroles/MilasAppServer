using Application.Entities;
using Application.Interfaces._01_Common;
using Data.Context;

namespace Data.Repositories.Kiosco
{
    public class GetByIdKioscoRepo : IGetByIdRepo<KioscoEntity>
    {
        private readonly AppDbContext _dbcontext;

        public GetByIdKioscoRepo(AppDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public async Task<KioscoEntity> GetByIdAsync(Guid entityId)
        {
            var kioscoModel = await _dbcontext.Kioscos.FindAsync(entityId);

            if (kioscoModel == null)
                return new KioscoEntity();

            return new KioscoEntity()
            {
                Id = kioscoModel.Id,
                Name = kioscoModel.Name,
                Manager = kioscoModel.Manager,
                Phone = kioscoModel.Phone,
                Address = kioscoModel.Address,
                UserId = kioscoModel.UserId,
                IsEnableChanges = kioscoModel.IsEnableChanges,
                Notes = kioscoModel.Notes,
                Dubt = kioscoModel.Dubt,
                Order = kioscoModel.Order,
            };
        }
    }
}
