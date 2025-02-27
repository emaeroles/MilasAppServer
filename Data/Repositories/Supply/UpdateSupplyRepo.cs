using Application.Entities;
using Application.Interfaces._01_Common;
using Data.Context;

namespace Data.Repositories.Supply
{
    public class UpdateSupplyRepo : IUpdateRepo<SupplyEntity>
    {
        private readonly AppDbContext _dbcontext;

        public UpdateSupplyRepo(AppDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public async Task<bool> UpdateAsync(SupplyEntity entity)
        {
            var uomModel = await _dbcontext.Uoms.FindAsync(entity.UoM.Id);
            if (uomModel == null)
                // TODO: Crear un error propio para manejar problemas de foreing keys y manejarlo con el middleware
                throw new InvalidOperationException("Unit of Mesure Id does not exist");

            var supplyModel = await _dbcontext.Supplies.FindAsync(entity.Id);

            if (supplyModel == null)
                return false;

            supplyModel.Name = entity.Name;
            supplyModel.Quantity = entity.Quantity;
            supplyModel.Uom = uomModel;
            supplyModel.CostPrice = entity.CostPrice;
            supplyModel.Yeild = entity.Yeild;
            await _dbcontext.SaveChangesAsync();

            return true;
        }
    }
}
