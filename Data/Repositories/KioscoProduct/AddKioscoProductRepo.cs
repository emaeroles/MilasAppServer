using Application.Entities;
using Application.Interfaces._01_Common;
using Data.Context;
using Data.Models;

namespace Data.Repositories.KioscoProduct
{
    public class AddKioscoProductRepo : IAddRepo<KioscoProductEntity>
    {
        private readonly AppDbContext _dbcontext;

        public AddKioscoProductRepo(AppDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public async Task<bool> AddAsync(KioscoProductEntity entity)
        {
            KioscoProductModel kioscoProductModel = new KioscoProductModel
            {
                ProductId = entity.ProductId,
                KioscoId = entity.KioscoId,
                KioscoPrice = entity.KioscoSalePrice,
                Stock = entity.Stock,
            };

            _dbcontext.KioscoProducts.Add(kioscoProductModel);
            int rows = await _dbcontext.SaveChangesAsync();

            if (rows == 0)
                return false;

            return true;
        }

    }
}
