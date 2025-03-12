using Application.Entities;
using Application.Interfaces._01_Common;
using Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.Kiosco
{
    public class GetAllKioscosRepo : IGetAllByActiveAndUserRepo
    {
        private readonly AppDbContext _dbContext;

        public GetAllKioscosRepo(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<KioscoEntity>?> GetAllByActiveAndUserAsync(bool isActive, Guid userId)
        {
            IQueryable<KioscoEntity> queryKiosco = _dbContext.Kioscos
                .Where(k => k.IsActive == isActive && k.UserId == userId)
                .Select(k => new KioscoEntity
                {
                    Id = k.Id,
                    Name = k.Name,
                    Manager = k.Manager,
                    Phone = k.Phone,
                    Address = k.Address,
                    UserId = k.UserId,
                    IsEnableChanges = k.IsEnableChanges,
                    Notes = k.Notes,
                    Dubt = k.Dubt,
                    Order = k.Order,
                    IsActive = k.IsActive
                });

            IEnumerable<KioscoEntity> listKioscoEntity = await queryKiosco.ToListAsync();

            if(!listKioscoEntity.Any())
                return null;

            return listKioscoEntity;
        }
    }
}
