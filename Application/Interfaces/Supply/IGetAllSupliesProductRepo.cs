using Application.Entities;

namespace Application.Interfaces.Supply
{
    public interface IGetAllSupliesProductRepo
    {
        public Task<IEnumerable<SupplyProductEntity>?> GetAllSupliesProductAsync(Guid productId);
    }
}
