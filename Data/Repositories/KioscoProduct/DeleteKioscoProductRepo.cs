using Application.Entities;
using Application.Interfaces._01_Common;
using Data.Context;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.KioscoProduct
{
    public class DeleteKioscoProductRepo : IDeleteComposedRepo<KioscoProductEntity>
    {
        private readonly AppDbContext _dbContext;

        public DeleteKioscoProductRepo(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> DeleteComposedAsync(Guid entityId, Guid byEntityId)
        {
            KioscoProductModel? productKioscoModel = await _dbContext.KioscoProducts
                .FirstOrDefaultAsync(sp => sp.ProductId == entityId && sp.KioscoId == byEntityId);

            if (productKioscoModel == null)
                throw new KeyNotFoundException($"No product found with Id {entityId} from kiosco {byEntityId}.");

            _dbContext.KioscoProducts.Remove(productKioscoModel);
            int rows = await _dbContext.SaveChangesAsync();

            if (rows == 0)
                return false;

            return true;
        }
    }
}
