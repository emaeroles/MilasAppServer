namespace Application.Interfaces._01_Common
{
    public interface IGetListByRepo<T>
    {
        public IEnumerable<T> GetListByAsync(int entityId);
    }
}
