using Application.Entities;
using Application.Interfaces._01_Common;
using Data.Context;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.ProductKiosco
{
    public class DeleteProductKioscoRepo : IDeleteComposedRepo<ProductKioscoEntity>
    {
        private readonly AppDbContext _dbcontext;

        public DeleteProductKioscoRepo(AppDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public async Task<bool> DeleteComposedAsync(Guid entityId, Guid byEntityId)
        {
            ProductsKioscoEntity? productKioscoModel = await _dbcontext.ProductsKioscos
                .FirstOrDefaultAsync(sp => sp.ProductId == entityId && sp.KioscoId == byEntityId);

            if (productKioscoModel == null)
                throw new KeyNotFoundException($"No supply product found with Id {entityId} from product {byEntityId}.");

            _dbcontext.ProductsKioscos.Remove(productKioscoModel);
            int rows = await _dbcontext.SaveChangesAsync();

            if (rows == 0)
                return false;

            return true;
        }
    }
}
