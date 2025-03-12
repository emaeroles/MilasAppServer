using Application.Entities;
using Application.Interfaces._01_Common;
using Data.Context;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.KioscoProduct
{
    public class DeleteKioscoProductRepo : IDeleteComposedRepo<KioscoProductEntity>
    {
        private readonly AppDbContext _dbcontext;

        public DeleteKioscoProductRepo(AppDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public async Task<bool> DeleteComposedAsync(Guid entityId, Guid byEntityId)
        {
            KioscoProductModel? productKioscoModel = await _dbcontext.KioscoProducts
                .FirstOrDefaultAsync(sp => sp.ProductId == entityId && sp.KioscoId == byEntityId);

            if (productKioscoModel == null)
                throw new KeyNotFoundException($"No product found with Id {entityId} from kiosco {byEntityId}.");

            _dbcontext.KioscoProducts.Remove(productKioscoModel);
            int rows = await _dbcontext.SaveChangesAsync();

            if (rows == 0)
                return false;

            return true;
        }
    }
}
