namespace Application.Interfaces._01_Common
{
    public interface IDeleteRepo<T>
    {
        public Task<bool> DeleteAsync(Guid entityId);
    }
}
