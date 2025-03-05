using Application.Entities;
using Application.Interfaces._01_Common;
using Data.Context;
using Data.Models;

namespace Data.Repositories.Supply
{
    public class GetByIdSupplyRepo : IGetByIdRepo<SupplyEntity>
    {
        private readonly AppDbContext _dbcontext;

        public GetByIdSupplyRepo(AppDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public async Task<SupplyEntity> GetByIdAsync(Guid entityId)
        {
            var supplyModel = await _dbcontext.Supplies.FindAsync(entityId);

            if (supplyModel == null)
                return new SupplyEntity();

            return new SupplyEntity()
            {
                Id = supplyModel.Id,
                Name = supplyModel.Name,
                Quantity = supplyModel.Quantity,
                UoM = new UoMEntity()
                {
                    Unit = supplyModel.Uom.Unit,
                },
                CostPrice = supplyModel.CostPrice,
                Yeild = supplyModel.Yeild,
            };
        }
    }
}
