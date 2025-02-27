using Application.Entities;
using Application.Interfaces._01_Common;
using Data.Context;

namespace Data.Repositories.Product
{
    public class UpdateProductRepo : IUpdateRepo<ProductEntity>
    {
        private readonly AppDbContext _dbcontext;

        public UpdateProductRepo(AppDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public async Task<bool> UpdateAsync(ProductEntity entity)
        {
            var productModel = await _dbcontext.Products.FindAsync(entity.Id);

            if (productModel == null)
                return false;

            productModel.Name = entity.Name;
            productModel.IsOwn = entity.IsOwn;
            productModel.CostPrice = entity.CostPrice;
            productModel.SalePrice = entity.SalePrice;
            await _dbcontext.SaveChangesAsync();

            return true;
        }
    }
}
