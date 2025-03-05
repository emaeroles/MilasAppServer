using Application.DTOs._01_Common;
using Application.Entities;
using Application.Factories;
using Application.Interfaces._01_Common;

namespace Application.UseCases.Kiosco
{
    public class ToggleIsChangesUseCase
    {
        private readonly IUpdateRepo<KioscoEntity> _updateRepo;
        private readonly IGetByIdRepo<KioscoEntity> _getByIdRepo;

        public ToggleIsChangesUseCase(
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

            kioscoEntity.IsEnableChanges = !kioscoEntity.IsEnableChanges;

            var isUpdated = await _updateRepo.UpdateAsync(kioscoEntity);

            if (!isUpdated)
                return ResultFactory.CreateNotUpdated("The kiosco activation was not changed");

            return ResultFactory.CreateSuccess("The kiosco activation was changed", null);
        }
    }
}
