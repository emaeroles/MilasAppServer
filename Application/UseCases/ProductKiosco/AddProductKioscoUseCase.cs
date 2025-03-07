using Application.DTOs._01_Common;
using Application.DTOs.ProductKiosco;
using Application.Entities;
using Application.Factories;
using Application.Interfaces._01_Common;
using AutoMapper;

namespace Application.UseCases.ProductKiosco
{
    public class AddProductKioscoUseCase
    {
        private readonly IAddRepo<ProductKioscoEntity> _addProductKioscoRepo;
        private readonly IGetByIdComposedRepo<ProductKioscoEntity> _getByIdComposedRepo;
        private readonly IGetByIdRepo<KioscoEntity> _getByIdKioscoRepo;
        private readonly IGetByIdRepo<ProductEntity> _getByIdProductRepo;
        private readonly IMapper _mapper;

        public AddProductKioscoUseCase(
            IAddRepo<ProductKioscoEntity> addProductKioscoRepo,
            IGetByIdComposedRepo<ProductKioscoEntity> getByIdComposedRepo,
            IGetByIdRepo<KioscoEntity> getByIdKioscoRepo,
            IGetByIdRepo<ProductEntity> getByIdProductRepo,
            IMapper mapper)
        {
            _addProductKioscoRepo = addProductKioscoRepo;
            _getByIdComposedRepo = getByIdComposedRepo;
            _getByIdKioscoRepo = getByIdKioscoRepo;
            _getByIdProductRepo = getByIdProductRepo;
            _mapper = mapper;
        }

        public async Task<AppResult> Execute(AddProductKioscoInput addProductKioscoInput)
        {
            ProductKioscoEntity? productKioscoEntityExist = await _getByIdComposedRepo
                .GetByIdComposedAsync(addProductKioscoInput.ProductId, addProductKioscoInput.KioscoId);
            if (productKioscoEntityExist != null)
                return ResultFactory.CreateConflict("The kiosco product already exists");

            KioscoEntity? kioscoEntity = await _getByIdKioscoRepo.GetByIdAsync(addProductKioscoInput.KioscoId);
            if (kioscoEntity == null)
                return ResultFactory.CreateNotFound("The kiosco does not exist");

            ProductEntity? productEntity = await _getByIdProductRepo.GetByIdAsync(addProductKioscoInput.ProductId);
            if (productEntity == null)
                return ResultFactory.CreateNotFound("The product does not exist");

            ProductKioscoEntity productKioscoEntity = _mapper.Map<ProductKioscoEntity>(addProductKioscoInput);
            productKioscoEntity.Id = Guid.NewGuid();
            productKioscoEntity.KioscoSalePrice = productEntity.CostPrice;
            productKioscoEntity.Stock = 0;

            bool isCreated = await _addProductKioscoRepo.AddAsync(productKioscoEntity);

            if (!isCreated)
                return ResultFactory.CreateNotCreated("The product kiosco was not created");

            return ResultFactory.CreateCreated("The product kiosco was created", productKioscoEntity.Id);
        }
    }
}
