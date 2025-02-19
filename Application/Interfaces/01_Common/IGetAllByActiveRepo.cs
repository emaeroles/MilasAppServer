namespace Application.Interfaces._01_Common
{
    public interface IGetAllByActiveRepo<T>
    {
        public IEnumerable<T> GetAllByActiveAsync(bool isActive);
    }
}
