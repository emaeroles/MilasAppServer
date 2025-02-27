namespace Application.Interfaces.Kiosco
{
    public interface IToggleIsChangesRepo
    {
        public Task<bool> ToggleIsChangesAsync(int entityId);
    }
}
