using Application.Enums;

namespace Application.Interfaces._01_Common
{
    public interface IDeleteComposedRepo
    {
        public Task<ResultState> DeleteComposedAsync(int entityId, int byEntityId);
    }
}
