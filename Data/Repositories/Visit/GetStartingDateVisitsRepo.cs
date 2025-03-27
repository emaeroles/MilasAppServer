using Application.Entities;
using Application.Interfaces.Visit;
using Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.Visit
{
    public class GetStartingDateVisitsRepo : IGetStartingDateVisitsRepo
    {
        private readonly AppDbContext _dbContext;

        public GetStartingDateVisitsRepo(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<VisitEntity>?> GetStartingDateVisitsAsync(Guid kioscoId, DateOnly date, int quantity)
        {
            IQueryable<VisitEntity> queryVisit = _dbContext.Visits
                .Where(v => DateOnly.FromDateTime(v.Date) <= date && kioscoId == v.KioscoId)
                .Take(quantity)
                .OrderBy(v => v.Date)
                .Select(v => new VisitEntity
                {
                    Id = v.Id,
                    Kiosco = new KioscoEntity
                    {
                        Id = v.Kiosco.Id,
                        Name = v.Kiosco.Name,
                        Manager = v.Kiosco.Manager,
                        Phone = v.Kiosco.Phone,
                        Address = v.Kiosco.Address,
                        UserId = v.Kiosco.UserId,
                        IsEnableChanges = v.Kiosco.IsEnableChanges,
                        Notes = v.Kiosco.Notes,
                        Dubt = v.Kiosco.Dubt,
                        Order = v.Kiosco.Order,
                        IsActive = v.Kiosco.IsActive
                    },
                    Date = v.Date,
                    VisitDetails = v.VisitDetails.Select(vd => new VisitDetailEntity
                    {
                        Id = vd.Id,
                        Product = new ProductEntity
                        {
                            Id = vd.ProductId,
                            Name = vd.Product.Name,
                            IsOwn = vd.Product.IsOwn,
                            CostPrice = vd.Product.CostPrice,
                            SalePrice = vd.Product.SalePrice,
                            IsActive = vd.Product.IsActive
                        },
                        Has = vd.Has,
                        Leave = vd.Leave,
                        Changes = vd.Changes,
                        Sold = vd.Sold,
                        HistSalePrice = vd.HistSalePrice
                    }).ToList()
                });

            IEnumerable<VisitEntity> listVisitEntity = await queryVisit.ToListAsync();

            if (!listVisitEntity.Any())
                return null;

            return listVisitEntity;
        }
    }
}
