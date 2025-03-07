using Application.Entities;

namespace Application.Interfaces.SupplyProduct
{
    public interface IGetAllSuppliesProductRepo
    {
        public Task<IEnumerable<SupplyProductEntity>?> GetAllSupliesProductAsync(Guid productId);
    }
}
