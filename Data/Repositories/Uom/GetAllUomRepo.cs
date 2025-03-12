using Application.Entities;
using Application.Interfaces._01_Common;
using Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.Uom
{
    public class GetAllUomRepo : IGetAllByActiveRepo<UomEntity>
    {
        private readonly AppDbContext _dbContext;

        public GetAllUomRepo(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<UomEntity>?> GetAllByActiveAsync(bool isActive)
        {
            IQueryable<UomEntity> queryUom = _dbContext.Uoms
                .Where(um => um.IsActive == isActive)
                .Select(um => new UomEntity
                {
                    Id = um.Id,
                    Unit = um.Unit,
                    IsActive = um.IsActive
                });

            IEnumerable<UomEntity> listUomEntity = await queryUom.ToListAsync();

            if (!listUomEntity.Any())
                return null;

            return listUomEntity;
        }
    }
}
