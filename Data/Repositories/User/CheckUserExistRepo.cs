using Application.Entities;
using Application.Enums;
using Application.Interfaces.User;
using Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.User
{
    public class CheckUserExistRepo : ICheckUserExistRepo
    {
        private readonly AppDbContext _dbcontext;

        public CheckUserExistRepo(AppDbContext dbContext)
        {
            _dbcontext = dbContext;
        }
        public async Task<bool> CheckUserExistAsync(string username)
        {
            var userModel = await _dbcontext.Users
                .FirstOrDefaultAsync(u => u.Username == username);

            if (userModel == null)
                return false;

            return true;
        }
    }
}
