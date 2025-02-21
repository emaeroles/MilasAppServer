using Application.Enums;

namespace Application.Interfaces._01_Common
{
    public interface IDeleteComposedRepo
    {
        public Task<bool> DeleteComposedAsync(int entityId, int byEntityId);
    }
}
