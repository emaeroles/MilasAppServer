using Application.Entities;
using Application.Interfaces.ProductKiosco;
using Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.ProductKiosco
{
    public class GetAllProductsKioscoRepo : IGetAllProductsKioscoRepo
    {
        private readonly AppDbContext _dbcontext;

        public GetAllProductsKioscoRepo(AppDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public async Task<IEnumerable<ProductKioscoEntity>?> GetAllProductsKioscoAsync(Guid kioscoId)
        {
            IQueryable<ProductKioscoEntity> queryProductsKiosco = _dbcontext.ProductsKioscos
                .Where(pk => pk.KioscoId == kioscoId)
                .Include(pk => pk.Product)
                .Where(pk => pk.Product.IsActive)
                .Select(pk => new ProductKioscoEntity
                {
                    Id = pk.Id,
                    ProductId = pk.ProductId,
                    KioscoId = pk.KioscoId,
                    Name = pk.Product.Name,
                    KioscoSalePrice = pk.KioscoPrice,
                    Stock = pk.Stock,
                });

            IEnumerable<ProductKioscoEntity> listProductKioscoEntity = await queryProductsKiosco.ToListAsync();

            if (!listProductKioscoEntity.Any())
                return null;

            return listProductKioscoEntity;
        }
    }
}
