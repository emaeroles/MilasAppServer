using Application.Entities;
using Application.Interfaces._01_Common;
using Data.Context;
using Data.Models;

namespace Data.Repositories.ProductSupply
{
    public class AddProductSupplyRepo : IAddRepo<ProductSupplyEntity>
    {
        private readonly AppDbContext _dbContext;

        public AddProductSupplyRepo(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> AddAsync(ProductSupplyEntity entity)
        {
            var productSupply = new Dictionary<string, object>
            {
                { "ProductId", entity.ProductId },
                { "SupplyId", entity.SupplyId }
            };

            _dbContext.Set<Dictionary<string, object>>("ProductSupply").Add(productSupply);
            int rows = await _dbContext.SaveChangesAsync();

            if (rows == 0)
                return false;

            return true;
        }
    }
}
