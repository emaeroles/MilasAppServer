using Application.Entities;
using Application.Interfaces._01_Common;
using Data.Context;

namespace Data.Repositories.Product
{
    public class GetByIdProductRepo : IGetByIdRepo<ProductEntity>
    {
        private readonly AppDbContext _dbcontext;

        public GetByIdProductRepo(AppDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public async Task<ProductEntity> GetListByAsync(Guid entityId)
        {
            var productModel = await _dbcontext.Products.FindAsync(entityId);

            if (productModel == null)
                return new ProductEntity();

            return new ProductEntity()
            {
                Id = productModel.Id,
                Name = productModel.Name,
                IsOwn = productModel.IsOwn,
                CostPrice = productModel.CostPrice,
                SalePrice = productModel.SalePrice,
            };
        }
    }
}
