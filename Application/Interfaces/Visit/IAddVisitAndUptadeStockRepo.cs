using Application.Entities;

namespace Application.Interfaces.Visit
{
    public interface IAddVisitAndUptadeStockRepo
    {
        public Task<bool> AddAndUpdateAsync(
            VisitEntity visitEntity, 
            List<KioscoProductEntity> productKioscoEntity);
    }
}
