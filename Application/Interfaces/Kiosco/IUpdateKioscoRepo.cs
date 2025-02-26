namespace Application.Interfaces.Kiosco
{
    public interface IUpdateKioscoRepo<T>
    {
        public Task<bool> UpdateNotesAsync(T entity);
        public Task<bool> UpdateDubtAsync(T entity);
        public Task<bool> UpdateOrderAsync(T entity);
    }
}
