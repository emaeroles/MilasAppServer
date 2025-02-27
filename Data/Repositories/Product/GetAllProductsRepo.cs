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

        public async Task<IEnumerable<ProductEntity>> GetAllByActiveAsync(bool isActive)
        {
            return await _dbcontext.Products
                .Where(s => s.IsActive == isActive)
                .Select(s => new ProductEntity
                {
                    Id = s.Id,
                    Name = s.Name,
                    IsOwn = s.IsOwn,
                    CostPrice = s.CostPrice,
                    SalePrice = s.SalePrice,
                }).ToListAsync();
        }
    }
}
