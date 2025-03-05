using Application.DTOs._01_Common;
using Application.DTOs.User;
using Application.Entities;
using Application.Factories;
using Application.Interfaces._01_Common;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace Application.UseCases.User
{
    public class UpdateUserUseCase
    {
        private readonly IUpdateRepo<UserEntity> _updateRepo;
        private readonly IGetByIdRepo<UserEntity> _getByIdRepo;
        private readonly IPasswordHasher<UserEntity> _passwordHasher;
        private readonly IMapper _mapper;

        public UpdateUserUseCase(
            IUpdateRepo<UserEntity> updateRepo,
            IGetByIdRepo<UserEntity> getByIdRepo,
            IPasswordHasher<UserEntity> passwordHasher,
            IMapper mapper) 
        {
            _updateRepo = updateRepo;
            _getByIdRepo = getByIdRepo;
            _passwordHasher = passwordHasher;
            _mapper = mapper;
        }

        public async Task<AppResult> Execute(UpdateUserInput updateUserInput)
        {
            UserEntity? userEntity = await _getByIdRepo.GetByIdAsync(updateUserInput.Id);

            if (userEntity == null)
                return ResultFactory.CreateNotFound("The user does not exist");

            userEntity = _mapper.Map<UserEntity>(updateUserInput);
            userEntity.Password = _passwordHasher.HashPassword(userEntity, updateUserInput.Password);

            var isUpdated = await _updateRepo.UpdateAsync(userEntity);
            if (!isUpdated)
                return ResultFactory.CreateNotFound($"The user was not updated, " +
                    $"id {updateUserInput.Id} does not exist");

            return ResultFactory.CreateSuccess("User was updated", null);
        }
    }
}
