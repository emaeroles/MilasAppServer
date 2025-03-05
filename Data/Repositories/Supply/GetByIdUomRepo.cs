using Application.Entities;
using Application.Interfaces._01_Common;
using Data.Context;
using Data.Models;

namespace Data.Repositories.Supply
{
    public class GetByIdUomRepo : IGetByIdRepo<UoMEntity>
    {
        private readonly AppDbContext _dbcontext;

        public GetByIdUomRepo(AppDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public async Task<UoMEntity?> GetByIdAsync(Guid entityId)
        {
            UomModel? uomModel = await _dbcontext.Uoms.FindAsync(entityId);

            if (uomModel == null)
                return null;

            return new UoMEntity()
            {
                Id = uomModel.Id,
                Unit = uomModel.Unit,
                IsActive = uomModel.IsActive
            };
        }
    }
}
