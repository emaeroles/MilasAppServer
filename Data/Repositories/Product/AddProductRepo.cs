using Application.Entities;
using Application.Interfaces._01_Common;
using Data.Context;
using Data.Models;

namespace Data.Repositories.Product
{
    public class AddProductRepo : IAddRepo<ProductEntity>
    {
        private readonly AppDbContext _dbcontext;

        public AddProductRepo(AppDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public async Task<bool> AddAsync(ProductEntity entity)
        {
            var productModel = new ProductModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                IsOwn = entity.IsOwn,
                CostPrice = entity.CostPrice,
                SalePrice = entity.SalePrice,
                IsActive = true,
            };

            _dbcontext.Products.Add(productModel);
            int rows = await _dbcontext.SaveChangesAsync();

            if (rows == 0)
                return false;

            return true;
        }
    }
}
