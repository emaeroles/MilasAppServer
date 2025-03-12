using Application.Entities;
using Application.Interfaces.User;
using Data.Context;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.User
{
    public class GetByUsernameRepo : IGetByUsernameRepo
    {
        private readonly AppDbContext _dbContext;

        public GetByUsernameRepo(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UserEntity?> GetByUsernameAsync(string username)
        {
            UserModel? userModel = await _dbContext.Users
                .FirstOrDefaultAsync(u => u.Username == username);

            if (userModel == null)
                return null;

            return new UserEntity()
            {
                Id = userModel.Id,
                Username = username,
                Password = userModel.Password,
                Email = userModel.Email,
                IsActive = userModel.IsActive,
            };
        }
    }
}
