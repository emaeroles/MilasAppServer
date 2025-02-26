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
        private readonly IMapper _mapper;

        public UpdateUserUseCase(
            IUpdateRepo<UserEntity> updateRepo,
            IMapper mapper) 
        {
            _updateRepo = updateRepo;
            _mapper = mapper;
        }

        public async Task<AppResult> Execute(UpdateUserInput updateUserInput)
        {
            var userEntity = _mapper.Map<UserEntity>(updateUserInput);

            var passwordHasher = new PasswordHasher<UserEntity>();
            userEntity.Password = passwordHasher.HashPassword(userEntity, updateUserInput.Password);

            var isOk = await _updateRepo.UpdateAsync(userEntity);
            if (!isOk)
                return ResultFactory.CreateNotFound("User was not updated");

            return ResultFactory.CreateSuccess("User was updated", null);
        }
    }
}
