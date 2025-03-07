using Application.Entities;

namespace Application.Interfaces.SupplyProduct
{
    public interface IGetAllSupliesProductRepo
    {
        public Task<IEnumerable<SupplyProductEntity>?> GetAllSupliesProductAsync(Guid productId);
    }
}
