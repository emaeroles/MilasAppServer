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
        private readonly ICheckUserExistRepo _checkUserExistRepo;
        private readonly IMapper _mapper;

        public AddUserUseCase(
            IAddRepo<UserEntity> addRepo,
            ICheckUserExistRepo checkUserExistRepo,
            IMapper mapper)
        {
            _addRepo = addRepo;
            _checkUserExistRepo = checkUserExistRepo;
            _mapper = mapper;
        }

        public async Task<AppResult> Execute(AddUserInput addUserInput)
        {
            addUserInput.Username = addUserInput.Username.ToLower();
            var isUserExist = await _checkUserExistRepo.CheckUserExistAsync(addUserInput.Username);
            if (isUserExist)
                return ResultFactory.CreateConflict("Username already exists");

            var userEntity = _mapper.Map<UserEntity>(addUserInput);
            userEntity.Id = Guid.NewGuid();

            var passwordHasher = new PasswordHasher<UserEntity>();
            userEntity.Password = passwordHasher.HashPassword(userEntity, addUserInput.Password);

            bool isCreated = await _addRepo.AddAsync(userEntity);

            if(!isCreated)
                return ResultFactory.CreateNotCreated("User was not created");

            return ResultFactory.CreateCreated("User was created", userEntity.Id);
        }
    }
}
