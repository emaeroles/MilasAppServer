using Application.Entities;
using Application.Interfaces.ProductSupply;
using Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.ProductSupply
{
    public class GetAllProductSuppliesRepo : IGetAllProductSuppliesRepo
    {
        private readonly AppDbContext _dbcontext;

        public GetAllProductSuppliesRepo(AppDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public async Task<IEnumerable<ProductSupplyEntity>?> GetAllProductSuppliesAsync(Guid productId)
        {
            IQueryable<ProductSupplyEntity> queryProductSupplies = _dbcontext.Supplies
                .Where(s => s.Products.Any(p => p.Id == productId))
                .Include(s => s.Uom)
                .Where(s => s.IsActive)
                .Select(s => new ProductSupplyEntity
                {
                    Id = s.Id,
                    SupplyId = s.Id,
                    ProductId = s.Id,
                    Name = s.Name,
                    Quantity = s.Quantity,
                    Uom = new UomEntity()
                    {
                        Id = s.Uom.Id,
                        Unit = s.Uom.Unit,
                        IsActive = s.Uom.IsActive
                    },
                    CostPrice = s.CostPrice,
                    Yeild = s.Yeild,
                });

            IEnumerable<ProductSupplyEntity> listProductSupplyEntity = await queryProductSupplies.ToListAsync();

            if (!listProductSupplyEntity.Any())
                return null;

            return listProductSupplyEntity;
        }
    }
}
