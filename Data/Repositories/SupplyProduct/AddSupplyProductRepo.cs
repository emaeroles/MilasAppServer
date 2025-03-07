using Application.Entities;
using Application.Interfaces._01_Common;
using Data.Context;
using Data.Models;

namespace Data.Repositories.SupplyProduct
{
    public class AddSupplyProductRepo : IAddRepo<SupplyProductEntity>
    {
        private readonly AppDbContext _dbcontext;

        public AddSupplyProductRepo(AppDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public async Task<bool> AddAsync(SupplyProductEntity entity)
        {
            SuppliesProductModel supplyProductModel = new SuppliesProductModel
            {
                Id = entity.Id,
                SupplyId = entity.SupplyId,
                ProductId = entity.ProductId,
            };

            _dbcontext.SuppliesProducts.Add(supplyProductModel);
            int rows = await _dbcontext.SaveChangesAsync();

            if (rows == 0)
                return false;

            return true;
        }
    }
}
