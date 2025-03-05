namespace Application.Interfaces._01_Common
{
    public interface IGetByIdRepo<T>
    {
        public Task<T?> GetByIdAsync(Guid entityId);
    }
}
