namespace Application.Interfaces._01_Common
{
    public interface IAddRepo<T>
    {
        public Task<bool> AddAsync(T entity);
    }
}
