namespace Application.Interfaces._01_Common
{
    public interface IDeleteComposedRepo<T>
    {
        public Task<bool> DeleteComposedAsync(Guid entityId, Guid byEntityId);
    }
}
