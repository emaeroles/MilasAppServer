using Application.DTOs._01_Common;
using Application.DTOs.Kiosco;
using Application.Entities;
using Application.Factories;
using Application.Interfaces._01_Common;
using AutoMapper;

namespace Application.UseCases.Kiosco
{
    public class UpdateOrderUseCase
    {
        private readonly IUpdateRepo<KioscoEntity> _updateRepo;
        private readonly IGetByIdRepo<KioscoEntity> _getByIdRepo;

        public UpdateOrderUseCase(
            IUpdateRepo<KioscoEntity> updateRepo,
            IGetByIdRepo<KioscoEntity> getByIdRepo)
        {
            _updateRepo = updateRepo;
            _getByIdRepo = getByIdRepo;
        }

        public async Task<AppResult> Execute(UpdateKioscoOrderInput updateKioscoOrderInput)
        {
            KioscoEntity? kioscoEntity = await _getByIdRepo.GetByIdAsync(updateKioscoOrderInput.Id);

            if (kioscoEntity == null)
                return ResultFactory.CreateNotFound("The kiosco does not exist");

            kioscoEntity.Order = updateKioscoOrderInput.Order;

            var isUpdated = await _updateRepo.UpdateAsync(kioscoEntity);

            if (!isUpdated)
                return ResultFactory.CreateNotUpdated("The kiosco order was not updated");

            return ResultFactory.CreateUpdated("The kiosco order was updated");
        }
    }
}
