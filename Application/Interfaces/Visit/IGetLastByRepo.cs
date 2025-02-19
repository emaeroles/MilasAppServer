using BL_Business.Entities;

namespace Application.Interfaces.Visit
{
    public interface IGetLastByRepo
    {
        public VisitEntity GetLastByAsync(int userId);
    }
}
