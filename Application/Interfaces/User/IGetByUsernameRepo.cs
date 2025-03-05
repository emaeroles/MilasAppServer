using Application.Entities;

namespace Application.Interfaces.User
{
    public interface IGetByUsernameRepo
    {
        public Task<UserEntity?> GetByUsernameAsync(string username);
    }
}
