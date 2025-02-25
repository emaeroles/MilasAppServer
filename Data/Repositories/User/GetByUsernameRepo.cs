using Application.Entities;
using Application.Interfaces.User;
using Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.User
{
    public class GetByUsernameRepo : IGetByUsernameRepo
    {
        private readonly AppDbContext _dbcontext;

        public GetByUsernameRepo(AppDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public async Task<UserEntity> GetByUsernameAsync(string username)
        {
            var userModel = await _dbcontext.Users
                .FirstOrDefaultAsync(u => u.Username == username);

            if (userModel == null)
                return new UserEntity();

            return new UserEntity()
            {
                Id = userModel.Id,
                Username = username,
                Password = userModel.Password,
                Email = userModel.Email,
            };
        }
    }
}
