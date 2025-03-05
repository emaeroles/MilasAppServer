using Application.Entities;
using Application.Interfaces._01_Common;
using Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.Product
{
    public class GetAllProductsRepo : IGetAllByActiveRepo<ProductEntity>
    {
        private readonly AppDbContext _dbcontext;

        public GetAllProductsRepo(AppDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public async Task<IEnumerable<ProductEntity>?> GetAllByActiveAsync(bool isActive)
        {
            IQueryable<ProductEntity> queryKiosco = _dbcontext.Products
                .Where(p => p.IsActive == isActive)
                .Select(p => new ProductEntity
                {
                    Id = p.Id,
                    Name = p.Name,
                    IsOwn = p.IsOwn,
                    CostPrice = p.CostPrice,
                    SalePrice = p.SalePrice,
                    IsActive = p.IsActive
                });

            IEnumerable<ProductEntity> listKioscoEntity = await queryKiosco.ToListAsync();

            if (!listKioscoEntity.Any())
                return null;

            return listKioscoEntity;
        }
    }
}
