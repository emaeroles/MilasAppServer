using Application.Entities;

namespace Application.Interfaces.Visit
{
    public interface IGetLastByRepo
    {
        public Task<VisitEntity> GetLastByAsync(int userId);
    }
}
