using Application.DTOs._01_Common;
using Application.DTOs.Supply;
using Application.Entities;
using Application.Factories;
using Application.Interfaces._01_Common;
using AutoMapper;

namespace Application.UseCases.Supply
{
    public class UpdateUomUseCase
    {
        private readonly IUpdateRepo<UoMEntity> _updateRepo;
        private readonly IMapper _mapper;

        public UpdateUomUseCase(
            IUpdateRepo<UoMEntity> updateRepo,
            IMapper mapper)
        {
            _updateRepo = updateRepo;
            _mapper = mapper;
        }

        public async Task<AppResult> Execute(UpdateUomInput updateUomInput)
        {
            var uomEntity = _mapper.Map<UoMEntity>(updateUomInput);

            var isOk = await _updateRepo.UpdateAsync(uomEntity);
            if (!isOk)
                return ResultFactory.CreateNotFound($"Unit of Mesure was not updated, " +
                    $"id {updateUomInput.Id} does not exist");

            return ResultFactory.CreateSuccess("Unit of Mesure was updated", null);
        }
    }
}
