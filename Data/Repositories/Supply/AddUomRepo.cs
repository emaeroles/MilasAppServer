using Application.Entities;
using Application.Interfaces._01_Common;
using Data.Context;
using Data.Models;

namespace Data.Repositories.Supply
{
    public class AddUomRepo : IAddRepo<UoMEntity>
    {
        private readonly AppDbContext _dbcontext;

        public AddUomRepo(AppDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public async Task<bool> AddAsync(UoMEntity entity)
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
