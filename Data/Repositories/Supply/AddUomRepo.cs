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

        public async Task<int> AddAsync(UoMEntity entity)
        {
            var uomModel = new UomModel()
            {
                Unit = entity.Unit,
            };

            _dbcontext.Uoms.Add(uomModel);
            int rows = await _dbcontext.SaveChangesAsync();

            return uomModel.Id;
        }
    }
}
