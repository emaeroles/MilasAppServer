using Application.Enums;

namespace Application.Interfaces._01_Common
{
    public interface IToggleActiveRepo
    {
        public ResultState ToggleActiveAsync(int entityId);
    }
}
