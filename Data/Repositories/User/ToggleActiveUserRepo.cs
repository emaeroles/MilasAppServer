using Application.Entities;
using Application.Interfaces._01_Common;
using Data.Context;

namespace Data.Repositories.User
{
    public class ToggleActiveUserRepo : IToggleActiveRepo<UserEntity>
    {
        private readonly AppDbContext _dbcontext;

        public ToggleActiveUserRepo(AppDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public async Task<bool> ToggleActiveAsync(int entityId)
        {
            var userModel = await _dbcontext.Users.FindAsync(entityId);

            if (userModel == null)
                return false;

            userModel.IsActive = !userModel.IsActive;

            int rows = await _dbcontext.SaveChangesAsync();

            if (rows == 0)
                return false;

            return true;
        }
    }
}
