using Application.Enums;
using Application.Interfaces._01_Common;
using Data.Context;

namespace Data.Repositories.User
{
    public class ToggleActiveRepo : IToggleActiveRepo
    {
        private readonly AppDbContext _dbcontext;

        public ToggleActiveRepo(AppDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public async Task<ResultState> ToggleActiveAsync(int entityId)
        {
            var userModel = await _dbcontext.Users.FindAsync(entityId);

            if (userModel == null)
                return ResultState.NotFound;

            userModel.IsActive = !userModel.IsActive;
            await _dbcontext.SaveChangesAsync();

            return ResultState.Success;
        }
    }
}
