using Application.Entities;
using Application.Interfaces._01_Common;
using Data.Context;
using Data.Models;

namespace Data.Repositories.Supply
{
    public class AddSupplyRepo : IAddRepo<SupplyEntity>
    {
        private readonly AppDbContext _dbcontext;

        public AddSupplyRepo(AppDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public async Task<bool> AddAsync(SupplyEntity entity)
        {
            var supplyModel = new SupplyModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                Quantity = entity.Quantity,
                UomId = entity.UoM.Id,
                CostPrice = entity.CostPrice,
                Yeild = entity.Yeild,
                IsActive = true,
            };

            _dbcontext.Supplies.Add(supplyModel);
            int rows = await _dbcontext.SaveChangesAsync();

            if (rows == 0)
                return false;

            return true;
        }
    }
}
