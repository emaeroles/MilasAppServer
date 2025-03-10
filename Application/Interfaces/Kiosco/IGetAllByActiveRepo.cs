using Application.Entities;

namespace Application.Interfaces._01_Common
{
    public interface IGetAllByActiveAndUserRepo
    {
        public Task<IEnumerable<KioscoEntity>?> GetAllByActiveAndUserAsync(bool isActive, Guid userId);
    }
}
