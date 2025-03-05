using Application.Entities;
using Application.Interfaces._01_Common;
using Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.Supply
{
    public class GetAllUomRepo : IGetAllByActiveRepo<UoMEntity>
    {
        private readonly AppDbContext _dbcontext;

        public GetAllUomRepo(AppDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public async Task<IEnumerable<UoMEntity>?> GetAllByActiveAsync(bool isActive)
        {
            IQueryable<UoMEntity> queryUom = _dbcontext.Uoms
                .Where(um => um.IsActive == isActive)
                .Select(um => new UoMEntity
                {
                    Id = um.Id,
                    Unit = um.Unit,
                    IsActive = um.IsActive
                });

            IEnumerable<UoMEntity> listUomEntity = await queryUom.ToListAsync();

            if (!listUomEntity.Any())
                return null;

            return listUomEntity;
        }
    }
}
