using Application.DTOs._01_Common;
using Application.DTOs.Kiosco;
using Application.Entities;
using Application.Factories;
using Application.Interfaces.Kiosco;
using AutoMapper;

namespace Application.UseCases.Kiosco
{
    public class UpdateOrderUseCase
    {
        private readonly IUpdateKioscoRepo<KioscoEntity> _updateRepo;
        private readonly IMapper _mapper;

        public UpdateOrderUseCase(
            IUpdateKioscoRepo<KioscoEntity> updateRepo,
            IMapper mapper)
        {
            _updateRepo = updateRepo;
            _mapper = mapper;
        }

        public async Task<AppResult> Execute(UpdateKioscoOrderInput updateKioscoOrderInput)
        {
            var kioscoEntity = _mapper.Map<KioscoEntity>(updateKioscoOrderInput);

            var isOk = await _updateRepo.UpdateOrderAsync(kioscoEntity);
            if (!isOk)
                return ResultFactory.CreateNotFound($"Order from kiosco was not updated, " +
                    $"id {updateKioscoOrderInput.Id} does not exist");

            return ResultFactory.CreateSuccess("Order from kiosco was updated", null);
        }
    }
}
