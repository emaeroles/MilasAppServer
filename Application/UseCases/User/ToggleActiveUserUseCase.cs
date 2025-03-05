using Application.DTOs._01_Common;
using Application.Entities;
using Application.Factories;
using Application.Interfaces._01_Common;

namespace Application.UseCases.User
{
    public class ToggleActiveUserUseCase
    {
        private readonly IUpdateRepo<UserEntity> _updateRepo;
        private readonly IGetByIdRepo<UserEntity> _getByIdRepo;

        public ToggleActiveUserUseCase(
            IUpdateRepo<UserEntity> updateRepo,
            IGetByIdRepo<UserEntity> getByIdRepo)
        {
            _updateRepo = updateRepo;
            _getByIdRepo = getByIdRepo;
        }

        public async Task<AppResult> Execute(Guid id)
        {
            UserEntity? userEntity = await _getByIdRepo.GetByIdAsync(id);

            if (userEntity == null)
                return ResultFactory.CreateNotFound("The user does not exist");

            userEntity.IsActive = !userEntity.IsActive;

            var isUpdated = await _updateRepo.UpdateAsync(userEntity);

            if (!isUpdated)
                return ResultFactory.CreateNotUpdated("The user activation was not changed");

            return ResultFactory.CreateUpdated("The user activation was changed");
        }
    }
}
