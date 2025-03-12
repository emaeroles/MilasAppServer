using Application.Entities;
using Application.Interfaces._01_Common;
using Data.Context;
using Data.Models;

namespace Data.Repositories.User
{
    public class AddUserRepo : IAddRepo<UserEntity>
    {
        private readonly AppDbContext _dbContext;

        public AddUserRepo(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> AddAsync(UserEntity entity)
        {
            UserModel userModel = new UserModel()
            {
                Id = entity.Id,
                Username = entity.Username,
                Password = entity.Password,
                Email = entity.Email,
                IsActive = entity.IsActive,
            };

            _dbContext.Users.Add(userModel);
            int rows = await _dbContext.SaveChangesAsync();

            if (rows == 0)
                return false;

            return true;
        }
    }
}
