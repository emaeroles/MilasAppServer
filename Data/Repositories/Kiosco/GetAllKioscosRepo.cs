using Application.Entities;
using Application.Interfaces._01_Common;
using Data.Context;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.Kiosco
{
    public class GetAllKioscosRepo : IGetAllByActiveRepo<KioscoEntity>
    {
        private readonly AppDbContext _dbcontext;

        public GetAllKioscosRepo(AppDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public async Task<IEnumerable<KioscoEntity>?> GetAllByActiveAsync(bool isActive)
        {
            IQueryable<KioscoEntity> queryKiosco = _dbcontext.Kioscos
                .Where(k => k.IsActive == isActive)
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
