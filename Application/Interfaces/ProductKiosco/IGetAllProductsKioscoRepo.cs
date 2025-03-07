using Application.Entities;

namespace Application.Interfaces.ProductKiosco
{
    public interface IGetAllProductsKioscoRepo
    {
        public Task<IEnumerable<ProductKioscoEntity>?> GetAllProductsKioscoAsync(Guid kioscoId);
    }
}
