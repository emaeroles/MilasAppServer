using Application.Enums;

namespace Application.Interfaces._01_Common
{
    public interface IDeleteRepo
    {
        public ResultState DeleteAsync(int entityId);
    }
}
