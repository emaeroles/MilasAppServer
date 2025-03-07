using Application.Entities;
using Application.Interfaces.SupplyProduct;
using Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.SupplyProduct
{
    public class GetAllSuppliesProductRepo : IGetAllSuppliesProductRepo
    {
        private readonly AppDbContext _dbcontext;

        public GetAllSuppliesProductRepo(AppDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public async Task<IEnumerable<SupplyProductEntity>?> GetAllSupliesProductAsync(Guid productId)
        {
            IQueryable<SupplyProductEntity> querySuppliesProduct = _dbcontext.SuppliesProducts
                .Where(sp => sp.ProductId == productId)
                .Include(sp => sp.Supply)
                    .ThenInclude(s => s.Uom)
                .Where(sp => sp.Supply.IsActive)
                .Select(sp => new SupplyProductEntity
                {
                    Id = sp.Id,
                    SupplyId = sp.SupplyId,
                    ProductId = sp.ProductId,
                    Name = sp.Supply.Name,
                    Quantity = sp.Supply.Quantity,
                    Uom = new UomEntity()
                    {
                        Id = sp.Supply.Uom.Id,
                        Unit = sp.Supply.Uom.Unit,
                        IsActive = sp.Supply.Uom.IsActive
                    },
                    CostPrice = sp.Supply.CostPrice,
                    Yeild = sp.Supply.Yeild,
                });

            IEnumerable<SupplyProductEntity> listSupplyProductEntity = await querySuppliesProduct.ToListAsync();

            if (!listSupplyProductEntity.Any())
                return null;

            return listSupplyProductEntity;
        }
    }
}
