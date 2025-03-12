using Application.Entities;
using Application.Interfaces._01_Common;
using Data.Context;
using Data.Models;

namespace Data.Repositories.Kiosco
{
    public class GetByIdKioscoRepo : IGetByIdRepo<KioscoEntity>
    {
        private readonly AppDbContext _dbContext;

        public GetByIdKioscoRepo(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<KioscoEntity?> GetByIdAsync(Guid entityId)
        {
            KioscoModel? kioscoModel = await _dbContext.Kioscos.FindAsync(entityId);

            if (kioscoModel == null)
                return null;

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
                IsActive = kioscoModel.IsActive
            };
        }
    }
}
