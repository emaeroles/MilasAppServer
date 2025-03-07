using Application.Entities;
using Application.Interfaces._01_Common;
using Data.Context;
using Data.Models;

namespace Data.Repositories.ProductKiosco
{
    public class AddProductKioscoRepo : IAddRepo<ProductKioscoEntity>
    {
        private readonly AppDbContext _dbcontext;

        public AddProductKioscoRepo(AppDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public async Task<bool> AddAsync(ProductKioscoEntity entity)
        {
            ProductsKioscoEntity productKioscoModel = new ProductsKioscoEntity
            {
                Id = entity.Id,
                ProductId = entity.ProductId,
                KioscoId = entity.KioscoId,
                KioscoPrice = entity.KioscoSalePrice,
                Stock = entity.Stock,
            };

            _dbcontext.ProductsKioscos.Add(productKioscoModel);
            int rows = await _dbcontext.SaveChangesAsync();

            if (rows == 0)
                return false;

            return true;
        }

    }
}
