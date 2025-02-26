using Application.DTOs._01_Common;
using Application.DTOs.Kiosco;
using Application.Entities;
using Application.Factories;
using Application.Interfaces.Kiosco;
using AutoMapper;

namespace Application.UseCases.Kiosco
{
    public class UpdateNotesUseCase
    {
        private readonly IUpdateKioscoRepo<KioscoEntity> _updateRepo;
        private readonly IMapper _mapper;

        public UpdateNotesUseCase(
            IUpdateKioscoRepo<KioscoEntity> updateRepo,
            IMapper mapper)
        {
            _updateRepo = updateRepo;
            _mapper = mapper;
        }

        public async Task<AppResult> Execute(UpdateKioscoNotesInput updateKioscoNotesInput)
        {
            var kioscoEntity = _mapper.Map<KioscoEntity>(updateKioscoNotesInput);

            var isOk = await _updateRepo.UpdateNotesAsync(kioscoEntity);
            if (!isOk)
                return ResultFactory.CreateNotFound("Notes from kiosco was not updated");

            return ResultFactory.CreateSuccess("Notes from kiosco was updated", null);
        }
    }
}
