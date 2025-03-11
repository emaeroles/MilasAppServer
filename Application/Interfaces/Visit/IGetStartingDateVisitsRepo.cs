using Application.Entities;

namespace Application.Interfaces.Visit
{
    public interface IGetStartingDateVisitsRepo
    {
        public Task<IEnumerable<VisitEntity>?> GetStartingDateVisitsAsync(DateOnly date, int quantity);
    }
}
