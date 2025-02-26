using Application.DTOs._01_Common;
using Application.DTOs.Kiosco;
using Application.Entities;
using Application.Factories;
using Application.Interfaces.Kiosco;
using AutoMapper;

namespace Application.UseCases.Kiosco
{
    public class UpdateDubtUseCase
    {
        private readonly IUpdateKioscoRepo<KioscoEntity> _updateRepo;
        private readonly IMapper _mapper;

        public UpdateDubtUseCase(
            IUpdateKioscoRepo<KioscoEntity> updateRepo,
            IMapper mapper)
        {
            _updateRepo = updateRepo;
            _mapper = mapper;
        }

        public async Task<AppResult> Execute(UpdateKioscoInput updateKioscoInput)
        {
            var kioscoEntity = _mapper.Map<KioscoEntity>(updateKioscoInput);

            var isOk = await _updateRepo.UpdateDubtAsync(kioscoEntity);
            if (!isOk)
                return ResultFactory.CreateNotFound("Dubt from kiosco was not updated");

            return ResultFactory.CreateSuccess("Dubt from kiosco was updated", null);
        }
    }
}
