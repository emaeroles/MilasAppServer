using Application.Entities;
using Application.Interfaces._01_Common;
using Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.ProductKiosco
{
    public class GetByIdProductKioscoRepo : IGetByIdComposedRepo<ProductKioscoEntity>
    {
        private readonly AppDbContext _dbcontext;

        public GetByIdProductKioscoRepo(AppDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public async Task<ProductKioscoEntity?> GetByIdComposedAsync(Guid entityId, Guid byEntityId)
        {
            IQueryable<ProductKioscoEntity> queryProductKiosco = _dbcontext.ProductsKioscos
                .Where(pk => pk.ProductId == entityId && pk.KioscoId == byEntityId)
                .Include(pk => pk.Product)
                .Select(pk => new ProductKioscoEntity
                {
                    Id = pk.Id,
                    ProductId = pk.ProductId,
                    KioscoId = pk.KioscoId,
                    Name = pk.Product.Name,
                    KioscoSalePrice = pk.KioscoPrice,
                    Stock = pk.Stock,
                });

            ProductKioscoEntity? productKioscoEntity = await queryProductKiosco.FirstOrDefaultAsync();

            if (productKioscoEntity == null)
                return null;

            return productKioscoEntity;
        }
    }
}
