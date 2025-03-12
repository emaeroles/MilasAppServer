using Application.Entities;
using Application.Interfaces.ProductSupply;
using Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.ProductSupply
{
    public class GetAllProductSuppliesRepo : IGetAllProductSuppliesRepo
    {
        private readonly AppDbContext _dbContext;

        public GetAllProductSuppliesRepo(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<ProductSupplyEntity>?> GetAllProductSuppliesAsync(Guid productId)
        {
            IQueryable<ProductSupplyEntity> queryProductSupplies = _dbContext.Supplies
                .Where(s => s.Products.Any(p => p.Id == productId))
                .Include(s => s.Uom)
                .Where(s => s.IsActive)
                .Select(s => new ProductSupplyEntity
                {
                    SupplyId = s.Id,
                    ProductId = productId,
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
