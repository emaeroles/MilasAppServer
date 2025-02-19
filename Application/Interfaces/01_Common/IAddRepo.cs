using Application.Enums;

namespace Application.Interfaces._01_Common
{
    public interface IAddRepo<T>
    {
        public ResultState AddAsync(T entity);
    }
}
