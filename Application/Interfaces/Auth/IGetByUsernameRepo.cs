using Application.Entities;

namespace Application.Interfaces.Auth
{
    public interface IGetByUsernameRepo
    {
        public Task<UserEntity> GetByUsernameAsync(string username);
    }
}
