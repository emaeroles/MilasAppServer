using Application.Entities;
using Application.Interfaces.Visit;
using Data.Context;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.Visit
{
    public class AddVisitAndUptadeStockRepo : IAddVisitAndUptadeStockRepo
    {
        private readonly AppDbContext _dbContext;

        public AddVisitAndUptadeStockRepo(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> AddAndUpdateAsync(
            VisitEntity visitEntity, 
            List<KioscoProductEntity> listProductKioscoEntity)
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    VisitModel visitModel = new VisitModel()
                    {
                        Id = visitEntity.Id,
                        KioscoId = visitEntity.Kiosco.Id,
                        Date = visitEntity.Date
                    };

                    _dbContext.Visits.Add(visitModel);
                    await _dbContext.SaveChangesAsync();

                    int counter = 0;
                    foreach (VisitDetailEntity visitDetailEntity in visitEntity.VisitDetails)
                    {
                        VisitDetailModel visitDetailModel = new VisitDetailModel()
                        {
                            Id = visitDetailEntity.Id,
                            VisitId = visitEntity.Id,
                            ProductId = visitDetailEntity.Product.Id,
                            Has = visitDetailEntity.Has,
                            Leave = visitDetailEntity.Leave,
                            Changes = visitDetailEntity.Changes,
                            Sold = visitDetailEntity.Sold,
                            HistSalePrice = visitDetailEntity.HistSalePrice
                        };

                        _dbContext.VisitDetails.Add(visitDetailModel);
                        await _dbContext.SaveChangesAsync();

                        KioscoProductModel? productKioscoModel = await _dbContext.KioscoProducts
                            .FirstOrDefaultAsync(pk => 
                                pk.ProductId == listProductKioscoEntity[counter].ProductId &&
                                pk.KioscoId == listProductKioscoEntity[counter].KioscoId);

                        if (productKioscoModel == null)
                        {
                            transaction.Rollback();
                            throw new KeyNotFoundException($"No product found with Id " +
                                $"{listProductKioscoEntity[counter].ProductId} from kiosco " +
                                $"{listProductKioscoEntity[counter].KioscoId}.");
                        }

                        productKioscoModel.Stock = listProductKioscoEntity[counter].Stock;

                        _dbContext.KioscoProducts.Update(productKioscoModel);
                        await _dbContext.SaveChangesAsync();

                        counter++;
                    }

                    transaction.Commit();
                    return true;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    return false;
                }
            }
        }
    }
}
