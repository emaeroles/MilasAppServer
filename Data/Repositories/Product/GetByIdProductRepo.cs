using Application.Entities;
using Application.Interfaces._01_Common;
using Data.Context;
using Data.Models;

namespace Data.Repositories.Product
{
    public class GetByIdProductRepo : IGetByIdRepo<ProductEntity>
    {
        private readonly AppDbContext _dbcontext;

        public GetByIdProductRepo(AppDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public async Task<ProductEntity?> GetByIdAsync(Guid entityId)
        {
            ProductModel? productModel = await _dbcontext.Products.FindAsync(entityId);

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
