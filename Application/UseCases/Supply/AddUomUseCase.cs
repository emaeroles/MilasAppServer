using Application.DTOs._01_Common;
using Application.DTOs.Supply;
using Application.Entities;
using Application.Factories;
using Application.Interfaces._01_Common;
using AutoMapper;

namespace Application.UseCases.Supply
{
    public class AddUomUseCase
    {
        private readonly IAddRepo<UoMEntity> _addUomRepo;
        private readonly IMapper _mapper;

        public AddUomUseCase(
            IAddRepo<UoMEntity> addUomRepo,
            IMapper mapper)
        {
            _addUomRepo = addUomRepo;
            _mapper = mapper;
        }

        public async Task<AppResult> Execute(AddUomInput addUomInput)
        {
            UoMEntity uomEntity = _mapper.Map<UoMEntity>(addUomInput);
            uomEntity.Id = Guid.NewGuid();
            uomEntity.IsActive = true;

            bool isCreated = await _addUomRepo.AddAsync(uomEntity);

            if (!isCreated)
                return ResultFactory.CreateNotCreated("The unit of mesure was not created");

            return ResultFactory.CreateCreated("The unit of mesure was created", uomEntity.Id);
        }
    }
}
