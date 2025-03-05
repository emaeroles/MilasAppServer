using Application.Entities;
using Application.Interfaces._01_Common;
using Data.Context;
using Data.Models;

namespace Data.Repositories.User
{
    public class AddUserRepo : IAddRepo<UserEntity>
    {
        private readonly AppDbContext _dbcontext;

        public AddUserRepo(AppDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public async Task<bool> AddAsync(UserEntity entity)
        {
            UserModel userModel = new UserModel()
            {
                Id = entity.Id,
                Username = entity.Username,
                Password = entity.Password,
                Email = entity.Email,
                IsActive = true,
            };

            _dbcontext.Users.Add(userModel);
            int rows = await _dbcontext.SaveChangesAsync();

            if (rows == 0)
                return false;

            return true;
        }
    }
}
