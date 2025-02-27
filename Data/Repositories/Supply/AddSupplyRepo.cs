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

        public async Task<int> AddAsync(SupplyEntity entity)
        {
            var uomModel = await _dbcontext.Uoms.FindAsync(entity.UoM.Id);
            if (uomModel == null)
                // TODO: Crear un error propio para manejar problemas de foreing keys y manejarlo con el middleware
                throw new InvalidOperationException("Unit of Mesure Id does not exist");

            var supplyModel = new SupplyModel()
            {
                Name = entity.Name,
                Quantity = entity.Quantity,
                Uom = uomModel,
                CostPrice = entity.CostPrice,
                Yeild = entity.Yeild,
                IsActive = true,
            };

            _dbcontext.Supplies.Add(supplyModel);
            int rows = await _dbcontext.SaveChangesAsync();

            return supplyModel.Id;
        }
    }
}
