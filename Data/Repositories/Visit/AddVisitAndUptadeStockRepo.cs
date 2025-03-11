using Application.Entities;
using Application.Interfaces.Visit;
using Data.Context;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.Visit
{
    public class AddVisitAndUptadeStockRepo : IAddVisitAndUptadeStockRepo
    {
        private readonly AppDbContext _dbcontext;

        public AddVisitAndUptadeStockRepo(AppDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public async Task<bool> AddAndUpdateAsync(
            VisitEntity visitEntity, 
            List<ProductKioscoEntity> listProductKioscoEntity)
        {
            using (var transaction = _dbcontext.Database.BeginTransaction())
            {
                try
                {
                    VisitModel visitModel = new VisitModel()
                    {
                        Id = visitEntity.Id,
                        KioscoId = visitEntity.Kiosco.Id,
                        Date = visitEntity.Date
                    };

                    _dbcontext.Visits.Add(visitModel);
                    await _dbcontext.SaveChangesAsync();

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

                        _dbcontext.VisitDetails.Add(visitDetailModel);
                        await _dbcontext.SaveChangesAsync();

                        ProductsKioscoModel? productKioscoModel = await _dbcontext.ProductsKioscos
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

                        _dbcontext.ProductsKioscos.Update(productKioscoModel);
                        await _dbcontext.SaveChangesAsync();

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
