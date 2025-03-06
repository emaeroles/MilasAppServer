using Application.DTOs._01_Common;
using Application.DTOs.Supply;
using Application.Entities;
using Application.Factories;
using Application.Interfaces._01_Common;
using AutoMapper;

namespace Application.UseCases.Supply
{
    public class AddSupplyProductUseCase
    {
        private readonly IAddRepo<SupplyProductEntity> _addUomRepo;
        private readonly IGetByIdComposedRepo<SupplyProductEntity> _getByIdComposedRepo;
        private readonly IMapper _mapper;

        public AddSupplyProductUseCase(
            IAddRepo<SupplyProductEntity> addUomRepo,
            IGetByIdComposedRepo<SupplyProductEntity> getByIdComposedRepo,
            IMapper mapper)
        {
            _addUomRepo = addUomRepo;
            _getByIdComposedRepo = getByIdComposedRepo;
            _mapper = mapper;
        }

        public async Task<AppResult> Execute(AddSupplyProductInput addSupplyProductInput)
        {
            SupplyProductEntity? supplyProductEntityExist = await _getByIdComposedRepo
                .GetByIdComposedAsync(addSupplyProductInput.SupplyId, addSupplyProductInput.ProductId);

            if (supplyProductEntityExist != null)
                return ResultFactory.CreateConflict("The supply product already exists");

            SupplyProductEntity supplyProductEntity = _mapper.Map<SupplyProductEntity>(addSupplyProductInput);
            supplyProductEntity.Id = Guid.NewGuid();

            bool isCreated = await _addUomRepo.AddAsync(supplyProductEntity);

            if (!isCreated)
                return ResultFactory.CreateNotCreated("The supply product was not created");

            return ResultFactory.CreateCreated("The supply product was created", supplyProductEntity.Id);
        }
    }
}
