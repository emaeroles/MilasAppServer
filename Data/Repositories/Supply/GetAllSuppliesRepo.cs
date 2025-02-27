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

        public async Task<IEnumerable<SupplyEntity>> GetAllByActiveAsync(bool isActive)
        {
            return await _dbcontext.Supplies
                .Where(s => s.IsActive == isActive)
                .Include(s => s.Uom)
                .Select(s => new SupplyEntity
                {
                    Id = s.Id,
                    Name = s.Name,
                    Quantity = s.Quantity,
                    UoM = new UoMEntity()
                    {
                        Unit = s.Uom.Unit,
                    },
                    CostPrice = s.CostPrice,
                    Yeild = s.Yeild,
                }).ToListAsync();
        }
    }
}
