using Application.DTOs._01_Common;
using Application.DTOs.Supply;
using Application.Entities;
using Application.Factories;
using Application.Interfaces._01_Common;

namespace Application.UseCases.Supply
{
    public class ToggleActiveUomUseCase
    {
        private readonly IUpdateRepo<UoMEntity> _updateRepo;
        private readonly IGetByIdRepo<UoMEntity> _getByIdRepo;

        public ToggleActiveUomUseCase(
            IUpdateRepo<UoMEntity> updateRepo,
            IGetByIdRepo<UoMEntity> getByIdRepo)
        {
            _updateRepo = updateRepo;
            _getByIdRepo = getByIdRepo;
        }

        public async Task<AppResult> Execute(Guid id)
        {
            UoMEntity? uomEntity = await _getByIdRepo.GetByIdAsync(id);

            if (uomEntity == null)
                return ResultFactory.CreateNotFound("The unit of mesure does not exist");

            uomEntity.IsActive = !uomEntity.IsActive;

            var isOk = await _updateRepo.UpdateAsync(uomEntity);
            if (!isOk)
                return ResultFactory.CreateNotUpdated("The unit of mesure activation was not changed");

            return ResultFactory.CreateUpdated("The unit of mesure activation was changed");
        }
    }
}
