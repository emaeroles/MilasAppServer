using Application.DTOs._01_Common;
using Application.DTOs.User;
using Application.Entities;
using Application.Enums;
using Application.Factories;
using Application.Interfaces._01_Common;
using Application.Interfaces.User;
using AutoMapper;

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
            int id = await _addRepo.AddAsync(userEntity);
            return ResultFactory.CreateCreated("User was created", id);
        }
    }
}
