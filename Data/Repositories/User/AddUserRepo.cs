using Application.Entities;
using Application.Enums;
using Application.Interfaces._01_Common;
using Data.Context;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.User
{
    public class AddUserRepo : IAddRepo<UserEntity>
    {
        private readonly AppDbContext _dbcontext;

        public AddUserRepo(AppDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public async Task<int> AddAsync(UserEntity entity)
        {
            var userModel = new UserModel()
            {
                Username = entity.Username,
                Password = entity.Password,
                Email = entity.Email,
                IsActive = true,
            };

            _dbcontext.Users.Add(userModel);
            int rows = await _dbcontext.SaveChangesAsync();

            return userModel.Id;
        }
    }
}
