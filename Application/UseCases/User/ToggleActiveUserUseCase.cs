using Application.DTOs._01_Common;
using Application.Entities;
using Application.Factories;
using Application.Interfaces._01_Common;
using Application.Interfaces.User;
using AutoMapper;

namespace Application.UseCases.User
{
    public class ToggleActiveUserUseCase
    {
        private readonly IToggleActiveRepo _toggleActiveRepo;
        private readonly ICheckUserExistRepo _checkUserExistRepo;
        private readonly IMapper _mapper;

        public ToggleActiveUserUseCase(
            IToggleActiveRepo toggleActiveRepo,
            ICheckUserExistRepo checkUserExistRepo,
            IMapper mapper)
        {
            _toggleActiveRepo = toggleActiveRepo;
            _checkUserExistRepo = checkUserExistRepo;
            _mapper = mapper;
        }

        public async Task<AppResult> Execute(int id)
        {
            var isOk = await _toggleActiveRepo.ToggleActiveAsync(id);
            if (!isOk)
                return ResultFactory.CreateNotFound("User was not exist");
            return ResultFactory.CreateSuccess("User activation was changed", null);
        }
    }
}
