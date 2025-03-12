using Application.Entities;

namespace Application.Interfaces.KioscoProduct
{
    public interface IGetAllKioscoProductsRepo
    {
        public Task<IEnumerable<KioscoProductEntity>?> GetAllKioscoProductsAsync(Guid kioscoId);
    }
}
