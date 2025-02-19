using Application.Enums;

namespace Application.Interfaces.User
{
    public interface ICheckUserExistRepo<T>
    {
        public ResultState CheckUserExistAsync(T entity);
    }
}
