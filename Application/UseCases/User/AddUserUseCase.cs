﻿using Application.DTOs._01_Common;
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
        private readonly IAddRepo<UserEntity> _addUserRepo;
        private readonly IGetByUsernameRepo _getByUsernameRepo;
        private readonly IPasswordHasher<UserEntity> _passwordHasher;
        private readonly IMapper _mapper;

        public AddUserUseCase(
            IAddRepo<UserEntity> addUserRepo,
            IGetByUsernameRepo getByUsernameRepo,
            IPasswordHasher<UserEntity> passwordHasher,
            IMapper mapper)
        {
            _addUserRepo = addUserRepo;
            _getByUsernameRepo = getByUsernameRepo;
            _passwordHasher = passwordHasher;
            _mapper = mapper;
        }

        public async Task<AppResult> Execute(AddUserInput addUserInput)
        {
            addUserInput.Username = addUserInput.Username.ToLower();

            UserEntity? userEntityExist = await _getByUsernameRepo.GetByUsernameAsync(addUserInput.Username);

            if (userEntityExist != null)
                return ResultFactory.CreateConflict("The username already exists");

            UserEntity userEntity = _mapper.Map<UserEntity>(addUserInput);
            userEntity.Id = Guid.NewGuid();
            userEntity.Password = _passwordHasher.HashPassword(userEntity, addUserInput.Password);
            userEntity.IsActive = true;
            
            bool isCreated = await _addUserRepo.AddAsync(userEntity);

            if(!isCreated)
                return ResultFactory.CreateNotCreated("The user was not created");

            return ResultFactory.CreateCreated("The user was created", userEntity.Id);
        }
    }
}
