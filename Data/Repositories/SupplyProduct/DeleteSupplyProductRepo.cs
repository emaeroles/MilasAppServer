using Application.Entities;
using Application.Interfaces._01_Common;
using Data.Context;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.SupplyProduct
{
    public class DeleteSupplyProductRepo : IDeleteComposedRepo<SupplyProductEntity>
    {
        private readonly AppDbContext _dbcontext;

        public DeleteSupplyProductRepo(AppDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public async Task<bool> DeleteComposedAsync(Guid entityId, Guid byEntityId)
        {
            SuppliesProductModel? suppliesProductModel = await _dbcontext.SuppliesProducts
                .FirstOrDefaultAsync(sp => sp.SupplyId == entityId && sp.ProductId == byEntityId);

            if (suppliesProductModel == null)
                throw new KeyNotFoundException($"No supply found with Id {entityId} from product {byEntityId}.");

            _dbcontext.SuppliesProducts.Remove(suppliesProductModel);
            int rows = await _dbcontext.SaveChangesAsync();

            if (rows == 0)
                return false;

            return true;
        }
    }
}
