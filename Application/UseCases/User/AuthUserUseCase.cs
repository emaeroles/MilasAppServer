using Application.DTOs._01_Common;
using Application.Entities;
using Application.Factories;
using Application.Interfaces.User;
using Microsoft.AspNetCore.Identity;

namespace Application.UseCases.User
{
    public class AuthUserUseCase
    {
        private readonly IGetByUsernameRepo _getByUsernameRepo;
        private readonly IPasswordHasher<UserEntity> _passwordHasher;

        public AuthUserUseCase(
            IGetByUsernameRepo getByUsernameRepo,
            IPasswordHasher<UserEntity> passwordHasher)
        {
            _getByUsernameRepo = getByUsernameRepo;
            _passwordHasher = passwordHasher;
        }

        public async Task<AppResult> Execute(string username, string password)
        {
            var userEntity = await _getByUsernameRepo.GetByUsernameAsync(username);

            if (userEntity.Id == Guid.Empty)
                return ResultFactory.CreateNotFound("User does not exist");

            var result = _passwordHasher.VerifyHashedPassword(userEntity, userEntity.Password, password);

            if (result != PasswordVerificationResult.Success)
            {
                return ResultFactory.CreateUnauthorized("The user is not authorized");
            }

            return ResultFactory.CreateAuthorized("The user is authorized");
        }
    }
}
