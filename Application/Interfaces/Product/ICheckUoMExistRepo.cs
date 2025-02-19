using Application.Enums;

namespace Application.Interfaces.Product
{
    public interface ICheckUoMExistRepo<T>
    {
        public ResultState CheckUoMExistAsync(T entity);
    }
}
