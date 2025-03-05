using Application.Entities;
using Application.Interfaces._01_Common;
using Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.Supply
{
    public class GetAllSuppliesRepo : IGetAllByActiveRepo<SupplyEntity>
    {
        private readonly AppDbContext _dbcontext;

        public GetAllSuppliesRepo(AppDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public async Task<IEnumerable<SupplyEntity>?> GetAllByActiveAsync(bool isActive)
        {
            IQueryable<SupplyEntity> queryKiosco = _dbcontext.Supplies
                .Where(s => s.IsActive == isActive)
                .Select(s => new SupplyEntity
                {
                    Id = s.Id,
                    Name = s.Name,
                    Quantity = s.Quantity,
                    UoM = new UoMEntity()
                    {
                        Id = s.Uom.Id,
                        Unit = s.Uom.Unit,
                        IsActive = s.Uom.IsActive
                    },
                    CostPrice = s.CostPrice,
                    Yeild = s.Yeild,
                    IsActive = s.IsActive
                });

            IEnumerable<SupplyEntity> listKioscoEntity = await queryKiosco.ToListAsync();

            if (!listKioscoEntity.Any())
                return null;

            return listKioscoEntity;
        }
    }
}
