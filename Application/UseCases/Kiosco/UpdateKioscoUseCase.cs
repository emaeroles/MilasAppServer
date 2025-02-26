using Application.DTOs._01_Common;
using Application.DTOs.Kiosco;
using Application.Entities;
using Application.Factories;
using Application.Interfaces._01_Common;
using AutoMapper;

namespace Application.UseCases.Kiosco
{
    public class UpdateKioscoUseCase
    {
        private readonly IUpdateRepo<KioscoEntity> _updateRepo;
        private readonly IMapper _mapper;

        public UpdateKioscoUseCase(
            IUpdateRepo<KioscoEntity> updateRepo,
            IMapper mapper)
        {
            _updateRepo = updateRepo;
            _mapper = mapper;
        }

        public async Task<AppResult> Execute(UpdateKioscoInput updateKioscoInput)
        {
            var kioscoEntity = _mapper.Map<KioscoEntity>(updateKioscoInput);

            var isOk = await _updateRepo.UpdateAsync(kioscoEntity);
            if (!isOk)
                return ResultFactory.CreateNotFound("Kiosco was not updated");

            return ResultFactory.CreateSuccess("Kiosco was updated", null);
        }
    }
}
