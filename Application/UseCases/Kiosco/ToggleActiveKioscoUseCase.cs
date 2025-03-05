using Application.DTOs._01_Common;
using Application.Entities;
using Application.Factories;
using Application.Interfaces._01_Common;

namespace Application.UseCases.Kiosco
{
    public class ToggleActiveKioscoUseCase
    {
        private readonly IUpdateRepo<KioscoEntity> _updateRepo;
        private readonly IGetByIdRepo<KioscoEntity> _getByIdRepo;

        public ToggleActiveKioscoUseCase(
            IUpdateRepo<KioscoEntity> updateRepo,
            IGetByIdRepo<KioscoEntity> getByIdRepo)
        {
            _updateRepo = updateRepo;
            _getByIdRepo = getByIdRepo;
        }

        public async Task<AppResult> Execute(Guid id)
        {
            KioscoEntity? kioscoEntity = await _getByIdRepo.GetByIdAsync(id);

            if (kioscoEntity == null)
                return ResultFactory.CreateNotFound("The kiosco does not exist");

            kioscoEntity.IsActive = !kioscoEntity.IsActive;

            var isUpdated = await _updateRepo.UpdateAsync(kioscoEntity);

            if (!isUpdated)
                return ResultFactory.CreateNotUpdated("The kiosco activation was not changed");

            return ResultFactory.CreateUpdated("The kiosco activation was changed");
        }
    }
}
