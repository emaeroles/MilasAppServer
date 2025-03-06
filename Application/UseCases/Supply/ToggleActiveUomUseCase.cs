using Application.DTOs._01_Common;
using Application.Entities;
using Application.Factories;
using Application.Interfaces._01_Common;

namespace Application.UseCases.Supply
{
    public class ToggleActiveUomUseCase
    {
        private readonly IUpdateRepo<UomEntity> _updateRepo;
        private readonly IGetByIdRepo<UomEntity> _getByIdRepo;

        public ToggleActiveUomUseCase(
            IUpdateRepo<UomEntity> updateRepo,
            IGetByIdRepo<UomEntity> getByIdRepo)
        {
            _updateRepo = updateRepo;
            _getByIdRepo = getByIdRepo;
        }

        public async Task<AppResult> Execute(Guid id)
        {
            UomEntity? uomEntity = await _getByIdRepo.GetByIdAsync(id);

            if (uomEntity == null)
                return ResultFactory.CreateNotFound("The unit of mesure does not exist");

            uomEntity.IsActive = !uomEntity.IsActive;

            bool isUpdated = await _updateRepo.UpdateAsync(uomEntity);
            if (!isUpdated)
                return ResultFactory.CreateNotUpdated("The unit of mesure activation was not changed");

            return ResultFactory.CreateUpdated("The unit of mesure activation was changed");
        }
    }
}
