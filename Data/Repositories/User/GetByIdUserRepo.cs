using Application.Entities;
using Application.Interfaces._01_Common;
using Data.Context;

namespace Data.Repositories.User
{
    public class GetByIdUserRepo : IGetByIdRepo<UserEntity>
    {
        private readonly AppDbContext _dbcontext;

        public GetByIdUserRepo(AppDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public async Task<UserEntity> GetListByAsync(Guid entityId)
        {
            var userModel = await _dbcontext.Users.FindAsync(entityId);

            if (userModel == null)
                return new UserEntity();

            return new UserEntity()
            {
                Id = userModel.Id,
                Username = userModel.Username,
                Email = userModel.Email,
            };
        }
    }
}
