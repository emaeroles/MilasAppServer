using Application.Entities;
using Application.Interfaces._01_Common;
using Data.Context;
using Data.Models;

namespace Data.Repositories.Product
{
    public class GetByIdProductRepo : IGetByIdRepo<ProductEntity>
    {
        private readonly AppDbContext _dbContext;

        public GetByIdProductRepo(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ProductEntity?> GetByIdAsync(Guid entityId)
        {
            ProductModel? productModel = await _dbContext.Products.FindAsync(entityId);

            if (productModel == null)
                return null;

            return new ProductEntity()
            {
                Id = productModel.Id,
                Name = productModel.Name,
                IsOwn = productModel.IsOwn,
                CostPrice = productModel.CostPrice,
                SalePrice = productModel.SalePrice,
                IsActive = productModel.IsActive
            };
        }
    }
}
