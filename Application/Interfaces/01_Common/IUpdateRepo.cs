namespace Application.Interfaces._01_Common
{
    public interface IUpdateRepo<T>
    {
        public Task<bool> UpdateAsync(T entity);
    }
}
