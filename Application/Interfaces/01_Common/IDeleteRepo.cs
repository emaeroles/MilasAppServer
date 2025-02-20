using Application.Enums;

namespace Application.Interfaces._01_Common
{
    public interface IDeleteRepo
    {
        public Task<ResultState> DeleteAsync(int entityId);
    }
}
