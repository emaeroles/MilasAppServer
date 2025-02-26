using Application.DTOs._01_Common;
using Application.Entities;
using Application.Factories;
using Application.Interfaces._01_Common;

namespace Application.UseCases.User
{
    public class ToggleActiveUserUseCase
    {
        private readonly IToggleActiveRepo<UserEntity> _toggleActiveRepo;

        public ToggleActiveUserUseCase(IToggleActiveRepo<UserEntity> toggleActiveRepo)
        {
            _toggleActiveRepo = toggleActiveRepo;
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
