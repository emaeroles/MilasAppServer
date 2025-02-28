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

        public AuthUserUseCase(IGetByUsernameRepo getByUsernameRepo)
        {
            _getByUsernameRepo = getByUsernameRepo;
        }

        public async Task<AppResult> Execute(string username, string password)
        {
            var userEntity = await _getByUsernameRepo.GetByUsernameAsync(username);

            if (userEntity.Id == 0)
                return ResultFactory.CreateNotFound("User does not exist");

            // TODO: Inyectar PasswordHasher y hacer test
            var passwordHasher = new PasswordHasher<UserEntity>();
            var result = passwordHasher.VerifyHashedPassword(
                userEntity, userEntity.Password, password);

            if (result != PasswordVerificationResult.Success)
            {
                return ResultFactory.CreateUnauthorized("The user is not authorized");
            }

            return ResultFactory.CreateAuthorized("The user is authorized");
        }
    }
}
