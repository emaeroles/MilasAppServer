using Application.DTOs._01_Common;
using Application.DTOs.User;
using Application.Entities;
using Application.Factories;
using Application.Interfaces.User;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace Application.UseCases.User
{
    public class AuthUserUseCase
    {
        private readonly IGetByUsernameRepo _getByUsernameRepo;
        private readonly IPasswordHasher<UserEntity> _passwordHasher;
        private readonly IMapper _mapper;

        public AuthUserUseCase(
            IGetByUsernameRepo getByUsernameRepo,
            IPasswordHasher<UserEntity> passwordHasher,
            IMapper mapper)
        {
            _getByUsernameRepo = getByUsernameRepo;
            _passwordHasher = passwordHasher;
            _mapper = mapper;
        }

        public async Task<AppResult> Execute(string username, string password)
        {
            UserEntity? userEntity = await _getByUsernameRepo.GetByUsernameAsync(username);

            if (userEntity == null)
                return ResultFactory.CreateNotFound("The username does not exist");

            PasswordVerificationResult result = _passwordHasher.VerifyHashedPassword(
                userEntity, userEntity.Password, password);

            if (result != PasswordVerificationResult.Success)
                return ResultFactory.CreateUnauthorized("The user is not authorized");

            GetUserOutput getUserOutput = _mapper.Map<GetUserOutput>(userEntity);

            return ResultFactory.CreateAuthorized("The user is authorized", getUserOutput);
        }
    }
}
