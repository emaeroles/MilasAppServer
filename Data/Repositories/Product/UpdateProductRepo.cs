using Application.Entities;
using Application.Interfaces._01_Common;
using Data.Context;

namespace Data.Repositories.Product
{
    public class UpdateProductRepo : IUpdateRepo<ProductEntity>
    {
        private readonly AppDbContext _dbContext;

        public UpdateProductRepo(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> UpdateAsync(ProductEntity entity)
        {
            var productModel = await _dbContext.Products.FindAsync(entity.Id);

            if (productModel == null)
                throw new KeyNotFoundException($"No product found with Id {entity.Id}.");

            productModel.Name = entity.Name;
            productModel.IsOwn = entity.IsOwn;
            productModel.CostPrice = entity.CostPrice;
            productModel.SalePrice = entity.SalePrice;
            productModel.IsActive = entity.IsActive;

            int rows = await _dbContext.SaveChangesAsync();

            if (rows == 0)
                return false;

            return true;
        }
    }
}
