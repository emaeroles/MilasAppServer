using Application.Entities;
using Application.Interfaces._01_Common;
using Data.Context;
using Data.Models;

namespace Data.Repositories.User
{
    public class GetByIdUserRepo : IGetByIdRepo<UserEntity>
    {
        private readonly AppDbContext _dbContext;

        public GetByIdUserRepo(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UserEntity?> GetByIdAsync(Guid entityId)
        {
            UserModel? userModel = await _dbContext.Users.FindAsync(entityId);

            if (userModel == null)
                return null;

            return new UserEntity()
            {
                Id = userModel.Id,
                Username = userModel.Username,
                Email = userModel.Email,
                IsActive = userModel.IsActive,
            };
        }
    }
}
