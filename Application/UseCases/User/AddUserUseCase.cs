using Application.DTOs._01_Common;
using Application.DTOs.User;
using Application.Entities;
using Application.Factories;
using Application.Interfaces._01_Common;
using Application.Interfaces.User;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace Application.UseCases.User
{
    public class AddUserUseCase
    {
        private readonly IAddRepo<UserEntity> _addRepo;
        private readonly IGetByUsernameRepo _getByUsernameRepo;
        private readonly IPasswordHasher<UserEntity> _passwordHasher;
        private readonly IMapper _mapper;

        public AddUserUseCase(
            IAddRepo<UserEntity> addRepo,
            IGetByUsernameRepo getByUsernameRepo,
            IPasswordHasher<UserEntity> passwordHasher,
            IMapper mapper)
        {
            _addRepo = addRepo;
            _getByUsernameRepo = getByUsernameRepo;
            _passwordHasher = passwordHasher;
            _mapper = mapper;
        }

        public async Task<AppResult> Execute(AddUserInput addUserInput)
        {
            addUserInput.Username = addUserInput.Username.ToLower();

            UserEntity? userEntity = await _getByUsernameRepo.GetByUsernameAsync(addUserInput.Username);

            if (userEntity != null)
                return ResultFactory.CreateConflict("The username already exists");

            userEntity = _mapper.Map<UserEntity>(addUserInput);
            userEntity.Id = Guid.NewGuid();
            userEntity.Password = _passwordHasher.HashPassword(userEntity, addUserInput.Password);
            userEntity.IsActive = true;
            
            bool isCreated = await _addRepo.AddAsync(userEntity);

            if(!isCreated)
                return ResultFactory.CreateNotCreated("The user was not created");

            return ResultFactory.CreateCreated("The user was created", userEntity.Id);
        }
    }
}
