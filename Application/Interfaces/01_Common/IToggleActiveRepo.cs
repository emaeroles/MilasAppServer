using Application.Enums;

namespace Application.Interfaces._01_Common
{
    public interface IToggleActiveRepo
    {
        public Task<ResultState> ToggleActiveAsync(int entityId);
    }
}
