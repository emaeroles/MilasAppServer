using Application.Enums;

namespace Application.Interfaces.Kiosco
{
    public interface IToggleIsChangesRepo
    {
        public Task<ResultState> ToggleIsChangesAsync(int entityId);
    }
}
