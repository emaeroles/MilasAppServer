using Application.Entities;
using Application.Interfaces._01_Common;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Data.Repositories.User
{
    public class GetAllUsersRepo : IGetAllByActiveRepo<UserEntity>
    {
        private readonly AppDbContext _dbcontext;

        public GetAllUsersRepo(AppDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public async Task<IEnumerable<UserEntity>> GetAllByActiveAsync(bool isActive)
        {
            return await _dbcontext.Users
                .Where(u => u.IsActive == isActive)
                .Select(u => new UserEntity
                {
                    Id = u.Id,
                    Username = u.Username,
                    Password = u.Password,
                    Email = u.Email,
                }).ToListAsync();
        }
    }
}
