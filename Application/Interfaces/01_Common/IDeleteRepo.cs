using Application.Enums;

namespace Application.Interfaces._01_Common
{
    public interface IDeleteRepo
    {
        public Task<bool> DeleteAsync(int entityId);
    }
}
