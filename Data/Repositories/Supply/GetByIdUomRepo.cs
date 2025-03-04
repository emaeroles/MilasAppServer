using Application.Entities;
using Application.Interfaces._01_Common;
using Data.Context;

namespace Data.Repositories.Supply
{
    public class GetByIdUomRepo : IGetByIdRepo<UoMEntity>
    {
        private readonly AppDbContext _dbcontext;

        public GetByIdUomRepo(AppDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public async Task<UoMEntity> GetListByAsync(Guid entityId)
        {
            var uomModel = await _dbcontext.Uoms.FindAsync(entityId);

            if (uomModel == null)
                return new UoMEntity();

            return new UoMEntity()
            {
                Id = uomModel.Id,
                Unit = uomModel.Unit,
            };
        }
    }
}
