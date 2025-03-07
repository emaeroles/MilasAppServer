using Application.DTOs._01_Common;
using Application.DTOs.SupplyProduct;
using Application.Entities;
using Application.Factories;
using Application.Interfaces._01_Common;
using AutoMapper;

namespace Application.UseCases.SupplyProduct
{
    public class AddSupplyProductUseCase
    {
        private readonly IAddRepo<SupplyProductEntity> _addUomRepo;
        private readonly IGetByIdComposedRepo<SupplyProductEntity> _getByIdComposedRepo;
        private readonly IGetByIdRepo<ProductEntity> _getByIdProductRepo;
        private readonly IGetByIdRepo<SupplyEntity> _getByIdSupplyRepo;
        private readonly IMapper _mapper;

        public AddSupplyProductUseCase(
            IAddRepo<SupplyProductEntity> addUomRepo,
            IGetByIdComposedRepo<SupplyProductEntity> getByIdComposedRepo,
            IGetByIdRepo<ProductEntity> getByIdProductRepo,
            IGetByIdRepo<SupplyEntity> getByIdSupplyRepo,
            IMapper mapper)
        {
            _addUomRepo = addUomRepo;
            _getByIdComposedRepo = getByIdComposedRepo;
            _getByIdProductRepo = getByIdProductRepo;
            _getByIdSupplyRepo = getByIdSupplyRepo;
            _mapper = mapper;
        }

        public async Task<AppResult> Execute(AddSupplyProductInput addSupplyProductInput)
        {
            SupplyProductEntity? supplyProductEntityExist = await _getByIdComposedRepo
                .GetByIdComposedAsync(addSupplyProductInput.SupplyId, addSupplyProductInput.ProductId);
            if (supplyProductEntityExist != null)
                return ResultFactory.CreateConflict("The product supply already exists");

            ProductEntity? productEntity = await _getByIdProductRepo.GetByIdAsync(addSupplyProductInput.ProductId);
            if (productEntity == null)
                return ResultFactory.CreateNotFound("The product does not exist");

            SupplyEntity? supplyEntity = await _getByIdSupplyRepo.GetByIdAsync(addSupplyProductInput.SupplyId);
            if (supplyEntity == null)
                return ResultFactory.CreateNotFound("The supply does not exist");

            SupplyProductEntity supplyProductEntity = _mapper.Map<SupplyProductEntity>(addSupplyProductInput);
            supplyProductEntity.Id = Guid.NewGuid();

            bool isCreated = await _addUomRepo.AddAsync(supplyProductEntity);

            if (!isCreated)
                return ResultFactory.CreateNotCreated("The product supply was not created");

            return ResultFactory.CreateCreated("The product supply was created", supplyProductEntity.Id);
        }
    }
}
