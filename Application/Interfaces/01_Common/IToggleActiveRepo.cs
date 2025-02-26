using Application.Enums;

namespace Application.Interfaces._01_Common
{
    public interface IToggleActiveRepo<T>
    {
        public Task<bool> ToggleActiveAsync(int entityId);
    }
}
