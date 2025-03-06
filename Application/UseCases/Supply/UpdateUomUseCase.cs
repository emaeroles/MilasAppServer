using Application.DTOs._01_Common;
using Application.DTOs.Supply;
using Application.Entities;
using Application.Factories;
using Application.Interfaces._01_Common;

namespace Application.UseCases.Supply
{
    public class UpdateUomUseCase
    {
        private readonly IUpdateRepo<UoMEntity> _updateRepo;
        private readonly IGetByIdRepo<UoMEntity> _getByIdRepo;

        public UpdateUomUseCase(
            IUpdateRepo<UoMEntity> updateRepo,
            IGetByIdRepo<UoMEntity> getByIdRepo)
        {
            _updateRepo = updateRepo;
            _getByIdRepo = getByIdRepo;
        }

        public async Task<AppResult> Execute(UpdateUomInput updateUomInput)
        {
            UoMEntity? uomEntity = await _getByIdRepo.GetByIdAsync(updateUomInput.Id);

            if (uomEntity == null)
                return ResultFactory.CreateNotFound("The unit of mesure does not exist");

            uomEntity.Unit = updateUomInput.Unit;

            bool isUpdated = await _updateRepo.UpdateAsync(uomEntity);
            if (!isUpdated)
                return ResultFactory.CreateNotUpdated("Unit of mesure was not updated");

            return ResultFactory.CreateUpdated("Unit of mesure was updated");
        }
    }
}
