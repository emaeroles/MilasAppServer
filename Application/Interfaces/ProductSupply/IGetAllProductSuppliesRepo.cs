using Application.Entities;

namespace Application.Interfaces.ProductSupply
{
    public interface IGetAllProductSuppliesRepo
    {
        public Task<IEnumerable<ProductSupplyEntity>?> GetAllProductSuppliesAsync(Guid productId);
    }
}
