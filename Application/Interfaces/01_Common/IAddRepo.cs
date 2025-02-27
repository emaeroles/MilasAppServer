namespace Application.Interfaces._01_Common
{
    public interface IAddRepo<T>
    {
        public Task<int> AddAsync(T entity);
    }
}
