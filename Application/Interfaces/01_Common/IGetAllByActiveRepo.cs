namespace Application.Interfaces._01_Common
{
    public interface IGetAllByActiveRepo<T>
    {
        public Task<IEnumerable<T>?> GetAllByActiveAsync(bool isActive);
    }
}
