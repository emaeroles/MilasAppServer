using Application.Entities;
using Application.Interfaces._01_Common;
using Data.Context;
using Data.Models;

namespace Data.Repositories.Product
{
    public class AddProductRepo : IAddRepo<ProductEntity>
    {
        private readonly AppDbContext _dbContext;

        public AddProductRepo(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> AddAsync(ProductEntity entity)
        {
            ProductModel productModel = new ProductModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                IsOwn = entity.IsOwn,
                CostPrice = entity.CostPrice,
                SalePrice = entity.SalePrice,
                IsActive = entity.IsActive,
            };

            _dbContext.Products.Add(productModel);
            int rows = await _dbContext.SaveChangesAsync();

            if (rows == 0)
                return false;

            return true;
        }
    }
}
