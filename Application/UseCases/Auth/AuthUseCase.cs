using Application.DTOs._01_Common;
using Application.DTOs.Auth;
using Application.DTOs.User;
using Application.Entities;
using Application.Factories;
using Application.Interfaces.Auth;
using Microsoft.AspNetCore.Identity;

namespace Application.UseCases.Auth
{
    public class AuthUseCase
    {
        private readonly IGetByUsernameRepo _getByUsernameRepo;

        public AuthUseCase(IGetByUsernameRepo getByUsernameRepo)
        {
            _getByUsernameRepo = getByUsernameRepo;
        }

        public async Task<AppResult> Execute(AuthInput authInput)
        {
            var userEntity = await _getByUsernameRepo.GetByUsernameAsync(authInput.Username);

            var passwordHasher = new PasswordHasher<UserEntity>();
            var result = passwordHasher.VerifyHashedPassword(
                userEntity, userEntity.Password, authInput.Password);

            return ResultFactory.CreateSuccess("", result);
        } 
    }
}
