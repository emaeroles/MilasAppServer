using Application.Entities;
using Application.Interfaces._01_Common;
using Data.Context;
using Data.Models;

namespace Data.Repositories.User
{
    public class UpdateUserRepo : IUpdateRepo<UserEntity>
    {
        private readonly AppDbContext _dbcontext;

        public UpdateUserRepo(AppDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public async Task<bool> UpdateAsync(UserEntity entity)
        {
            UserModel? userModel = await _dbcontext.Users.FindAsync(entity.Id);

            if (userModel == null)
                throw new KeyNotFoundException($"No user found with Id {entity.Id}.");

            userModel.Username = entity.Username;
            userModel.Password = entity.Password;
            userModel.Email = entity.Email;
            userModel.IsActive = entity.IsActive;

            int rows = await _dbcontext.SaveChangesAsync();

            if (rows == 0)
                return false;

            return true;
        }
    }
}
