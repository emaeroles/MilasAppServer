using Application.Entities;

namespace Application.Interfaces.Visit
{
    public interface IGetStartingDateVisitsRepo
    {
        public Task<IEnumerable<VisitEntity>?> GetStartingDateVisitsAsync(Guid kioscoId, DateOnly date, int quantity);
    }
}
