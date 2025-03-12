using Application.Entities;
using Application.Interfaces._01_Common;
using Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.KioscoProduct
{
    public class GetByIdKioscoProductRepo : IGetByIdComposedRepo<KioscoProductEntity>
    {
        private readonly AppDbContext _dbcontext;

        public GetByIdKioscoProductRepo(AppDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public async Task<KioscoProductEntity?> GetByIdComposedAsync(Guid entityId, Guid byEntityId)
        {
            IQueryable<KioscoProductEntity> queryKioscoProduct = _dbcontext.KioscoProducts
                .Where(pk => pk.ProductId == entityId && pk.KioscoId == byEntityId)
                .Include(pk => pk.Product)
                .Select(pk => new KioscoProductEntity
                {
                    ProductId = pk.ProductId,
                    KioscoId = pk.KioscoId,
                    Name = pk.Product.Name,
                    KioscoSalePrice = pk.KioscoPrice,
                    Stock = pk.Stock,
                });

            KioscoProductEntity? kioscoProductEntity = await queryKioscoProduct.FirstOrDefaultAsync();

            if (kioscoProductEntity == null)
                return null;

            return kioscoProductEntity;
        }
    }
}
