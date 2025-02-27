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

        public async Task<int> AddAsync(ProductEntity entity)
        {
            var productModel = new ProductModel()
            {
                Name = entity.Name,
                IsOwn = entity.IsOwn,
                CostPrice = entity.CostPrice,
                SalePrice = entity.SalePrice,
                IsActive = true,
            };

            _dbcontext.Products.Add(productModel);
            int rows = await _dbcontext.SaveChangesAsync();

            return productModel.Id;
        }
    }
}
