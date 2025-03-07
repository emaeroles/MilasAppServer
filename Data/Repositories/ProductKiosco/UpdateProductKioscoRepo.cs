using Application.Entities;
using Application.Interfaces._01_Common;
using Data.Context;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.ProductKiosco
{
    public class UpdateProductKioscoRepo : IUpdateRepo<ProductKioscoEntity>
    {
        private readonly AppDbContext _dbcontext;

        public UpdateProductKioscoRepo(AppDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public async Task<bool> UpdateAsync(ProductKioscoEntity entity)
        {
            ProductsKioscoModel? productKioscoModel = await _dbcontext.ProductsKioscos
                .FirstOrDefaultAsync(pk => pk.ProductId == entity.ProductId && pk.KioscoId == entity.KioscoId);

            if (productKioscoModel == null)
                throw new KeyNotFoundException($"No supply found with Id {entity.Id}.");

            productKioscoModel.KioscoPrice = entity.KioscoSalePrice;
            productKioscoModel.Stock = entity.Stock;

            int rows = await _dbcontext.SaveChangesAsync();

            if (rows == 0)
                return false;

            return true;
        }
    }
}
