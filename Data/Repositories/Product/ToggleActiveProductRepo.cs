using Application.Entities;
using Application.Interfaces._01_Common;
using Data.Context;

namespace Data.Repositories.Product
{
    public class ToggleActiveProductRepo : IToggleActiveRepo<ProductEntity>
    {
        private readonly AppDbContext _dbcontext;

        public ToggleActiveProductRepo(AppDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public async Task<bool> ToggleActiveAsync(int entityId)
        {
            var productModel = await _dbcontext.Products.FindAsync(entityId);

            if (productModel == null)
                return false;

            productModel.IsActive = !productModel.IsActive;
            await _dbcontext.SaveChangesAsync();

            return true;
        }
    }
}
