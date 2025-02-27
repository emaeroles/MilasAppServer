namespace Application.Interfaces._01_Common
{
    public interface IDeleteComposedRepo<T>
    {
        public Task<bool> DeleteComposedAsync(int entityId, int byEntityId);
    }
}
