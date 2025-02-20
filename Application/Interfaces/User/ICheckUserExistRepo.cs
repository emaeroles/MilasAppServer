using Application.Entities;
using Application.Enums;

namespace Application.Interfaces.User
{
    public interface ICheckUserExistRepo
    {
        public Task<bool> CheckUserExistAsync(string username);
    }
}
