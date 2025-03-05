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

        public async Task<IEnumerable<UserEntity>?> GetAllByActiveAsync(bool isActive)
        {
            IQueryable<UserEntity> queryUser = _dbcontext.Users
                .Where(u => u.IsActive == isActive)
                .Select(u => new UserEntity
                {
                    Id = u.Id,
                    Username = u.Username,
                    Email = u.Email,
                    IsActive = u.IsActive
                });

            IEnumerable<UserEntity> listUserEntity = await queryUser.ToListAsync();

            if (!listUserEntity.Any())
                return null;

            return listUserEntity;
        }
    }
}
