using Application.Entities;
using Application.Interfaces._01_Common;
using Data.Context;
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

        public async Task<IEnumerable<KioscoEntity>> GetAllByActiveAsync(bool isActive)
        {
            return await _dbcontext.Kioscos
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
                    Order = k.Order ?? 0, // TODO: sacar "?? 0" cuando se pueda
                }).ToListAsync();
        }
    }
}
