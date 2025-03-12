using Application.Entities;
using Application.Interfaces._01_Common;
using Data.Context;
using Data.Models;

namespace Data.Repositories.Uom
{
    public class GetByIdUomRepo : IGetByIdRepo<UomEntity>
    {
        private readonly AppDbContext _dbContext;

        public GetByIdUomRepo(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UomEntity?> GetByIdAsync(Guid entityId)
        {
            UomModel? uomModel = await _dbContext.Uoms.FindAsync(entityId);

            if (uomModel == null)
                return null;

            return new UomEntity()
            {
                Id = uomModel.Id,
                Unit = uomModel.Unit,
                IsActive = uomModel.IsActive
            };
        }
    }
}
