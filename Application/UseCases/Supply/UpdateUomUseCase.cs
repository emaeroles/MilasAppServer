using Application.DTOs._01_Common;
using Application.DTOs.Supply;
using Application.Entities;
using Application.Factories;
using Application.Interfaces._01_Common;

namespace Application.UseCases.Supply
{
    public class UpdateUomUseCase
    {
        private readonly IUpdateRepo<UomEntity> _updateRepo;
        private readonly IGetByIdRepo<UomEntity> _getByIdRepo;

        public UpdateUomUseCase(
            IUpdateRepo<UomEntity> updateRepo,
            IGetByIdRepo<UomEntity> getByIdRepo)
        {
            _updateRepo = updateRepo;
            _getByIdRepo = getByIdRepo;
        }

        public async Task<AppResult> Execute(UpdateUomInput updateUomInput)
        {
            UomEntity? uomEntity = await _getByIdRepo.GetByIdAsync(updateUomInput.Id);

            if (uomEntity == null)
                return ResultFactory.CreateNotFound("The unit of mesure does not exist");

            uomEntity.Unit = updateUomInput.Unit;

            bool isUpdated = await _updateRepo.UpdateAsync(uomEntity);
            if (!isUpdated)
                return ResultFactory.CreateNotUpdated("The unit of mesure was not updated");

            return ResultFactory.CreateUpdated("The unit of mesure was updated");
        }
    }
}
