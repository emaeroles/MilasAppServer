using Application.Entities;
using Application.Interfaces.KioscoProduct;
using Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.KioscoProduct
{
    public class GetAllKioscoProductsRepo : IGetAllKioscoProductsRepo
    {
        private readonly AppDbContext _dbcontext;

        public GetAllKioscoProductsRepo(AppDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public async Task<IEnumerable<KioscoProductEntity>?> GetAllKioscoProductsAsync(Guid kioscoId)
        {
            IQueryable<KioscoProductEntity> queryKioscoProducts = _dbcontext.KioscoProducts
                .Where(pk => pk.KioscoId == kioscoId)
                .Include(pk => pk.Product)
                .Where(pk => pk.Product.IsActive)
                .Select(pk => new KioscoProductEntity
                {
                    ProductId = pk.ProductId,
                    KioscoId = pk.KioscoId,
                    Name = pk.Product.Name,
                    KioscoSalePrice = pk.KioscoPrice,
                    Stock = pk.Stock,
                });

            IEnumerable<KioscoProductEntity> listKioscoProductEntity = await queryKioscoProducts.ToListAsync();

            if (!listKioscoProductEntity.Any())
                return null;

            return listKioscoProductEntity;
        }
    }
}
