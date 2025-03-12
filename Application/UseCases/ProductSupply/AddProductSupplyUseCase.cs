using Application.DTOs._01_Common;
using Application.DTOs.ProductSupply;
using Application.Entities;
using Application.Factories;
using Application.Interfaces._01_Common;
using AutoMapper;

namespace Application.UseCases.ProductSupply
{
    public class AddProductSupplyUseCase
    {
        private readonly IAddRepo<ProductSupplyEntity> _addProductSupplyRepo;
        private readonly IGetByIdComposedRepo<ProductSupplyEntity> _getByIdComposedRepo;
        private readonly IGetByIdRepo<ProductEntity> _getByIdProductRepo;
        private readonly IGetByIdRepo<SupplyEntity> _getByIdSupplyRepo;
        private readonly IMapper _mapper;

        public AddProductSupplyUseCase(
            IAddRepo<ProductSupplyEntity> addProductSupplyRepo,
            IGetByIdComposedRepo<ProductSupplyEntity> getByIdComposedRepo,
            IGetByIdRepo<ProductEntity> getByIdProductRepo,
            IGetByIdRepo<SupplyEntity> getByIdSupplyRepo,
            IMapper mapper)
        {
            _addProductSupplyRepo = addProductSupplyRepo;
            _getByIdComposedRepo = getByIdComposedRepo;
            _getByIdProductRepo = getByIdProductRepo;
            _getByIdSupplyRepo = getByIdSupplyRepo;
            _mapper = mapper;
        }

        public async Task<AppResult> Execute(AddProductSupplyInput addProductSupplyInput)
        {
            ProductSupplyEntity? productSupplyEntityExist = await _getByIdComposedRepo
                .GetByIdComposedAsync(addProductSupplyInput.SupplyId, addProductSupplyInput.ProductId);
            if (productSupplyEntityExist != null)
                return ResultFactory.CreateConflict("The product supply already exists");

            ProductEntity? productEntity = await _getByIdProductRepo.GetByIdAsync(addProductSupplyInput.ProductId);
            if (productEntity == null)
                return ResultFactory.CreateNotFound("The product does not exist");

            SupplyEntity? supplyEntity = await _getByIdSupplyRepo.GetByIdAsync(addProductSupplyInput.SupplyId);
            if (supplyEntity == null)
                return ResultFactory.CreateNotFound("The supply does not exist");

            ProductSupplyEntity productsupplyEntity = _mapper.Map<ProductSupplyEntity>(addProductSupplyInput);

            bool isCreated = await _addProductSupplyRepo.AddAsync(productsupplyEntity);

            if (!isCreated)
                return ResultFactory.CreateNotCreated("The product supply was not created");

            return ResultFactory.CreateCreated("The product supply was created", null);
        }
    }
}
