using Application.DTOs._01_Common;
using Application.DTOs.Kiosco;
using Application.Entities;
using Application.Factories;
using Application.Interfaces._01_Common;

namespace Application.UseCases.Kiosco
{
    public class UpdateKioscoUseCase
    {
        private readonly IUpdateRepo<KioscoEntity> _updateRepo;
        private readonly IGetByIdRepo<KioscoEntity> _getByIdRepo;

        public UpdateKioscoUseCase(
            IUpdateRepo<KioscoEntity> updateRepo,
            IGetByIdRepo<KioscoEntity> getByIdRepo)
        {
            _updateRepo = updateRepo;
            _getByIdRepo = getByIdRepo;
        }

        public async Task<AppResult> Execute(UpdateKioscoInput updateKioscoInput)
        {
            KioscoEntity? kioscoEntity = await _getByIdRepo.GetByIdAsync(updateKioscoInput.Id);

            if (kioscoEntity == null)
                return ResultFactory.CreateNotFound("The kiosco does not exist");

            kioscoEntity.Name = updateKioscoInput.Name;
            kioscoEntity.Manager = updateKioscoInput.Manager;
            kioscoEntity.Phone = updateKioscoInput.Phone;
            kioscoEntity.Address = updateKioscoInput.Address;

            var isUpdated = await _updateRepo.UpdateAsync(kioscoEntity);

            if (!isUpdated)
                return ResultFactory.CreateNotUpdated("The kiosco was not updated");

            return ResultFactory.CreateSuccess("The kiosco was updated", null);
        }
    }
}
