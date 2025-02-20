namespace Application.Interfaces._01_Common
{
    public interface IGetListByRepo<T>
    {
        public Task<IEnumerable<T>> GetListByAsync(int entityId);
    }
}
