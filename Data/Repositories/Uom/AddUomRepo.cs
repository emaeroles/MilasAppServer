using Application.Entities;
using Application.Interfaces._01_Common;
using Data.Context;
using Data.Models;

namespace Data.Repositories.Uom
{
    public class AddUomRepo : IAddRepo<UomEntity>
    {
        private readonly AppDbContext _dbcontext;

        public AddUomRepo(AppDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public async Task<bool> AddAsync(UomEntity entity)
        {
            UomModel uomModel = new UomModel()
            {
                Id = entity.Id,
                Unit = entity.Unit,
                IsActive = entity.IsActive,
            };

            _dbcontext.Uoms.Add(uomModel);
            int rows = await _dbcontext.SaveChangesAsync();

            if (rows == 0)
                return false;

            return true;
        }
    }
}
