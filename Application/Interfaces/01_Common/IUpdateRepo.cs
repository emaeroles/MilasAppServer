using Application.Enums;

namespace Application.Interfaces._01_Common
{
    public interface IUpdateRepo<T>
    {
        public ResultState UpdateAsync(T entity);
    }
}
