using Application.Entities;
using Application.Interfaces._01_Common;
using Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.SupplyProduct
{
    public class GetByIdSupplyProductRepo : IGetByIdComposedRepo<SupplyProductEntity>
    {
        private readonly AppDbContext _dbcontext;

        public GetByIdSupplyProductRepo(AppDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public async Task<SupplyProductEntity?> GetByIdComposedAsync(Guid entityId, Guid byEntityId)
        {
            IQueryable<SupplyProductEntity> querySupplyProduct = _dbcontext.SuppliesProducts
                .Where(sp => sp.SupplyId == entityId && sp.ProductId == byEntityId)
                .Select(sp => new SupplyProductEntity
                {
                    Id = sp.Id,
                    SupplyId = sp.SupplyId,
                    ProductId = sp.ProductId,
                });

            SupplyProductEntity? supplieProductEntity = await querySupplyProduct.FirstOrDefaultAsync();

            if (supplieProductEntity == null)
                return null;

            return supplieProductEntity;
        }
    }
}
