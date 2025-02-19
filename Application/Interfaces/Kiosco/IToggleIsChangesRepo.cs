using Application.Enums;

namespace Application.Interfaces.Kiosco
{
    public interface IToggleIsChangesRepo
    {
        public ResultState ToggleIsChangesAsync(int entityId);
    }
}
