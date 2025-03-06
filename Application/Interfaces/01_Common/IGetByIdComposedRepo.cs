namespace Application.Interfaces._01_Common
{
    public interface IGetByIdComposedRepo<T>
    {
        public Task<T?> GetByIdComposedAsync(Guid entityId, Guid byEntityId);
    }
}
