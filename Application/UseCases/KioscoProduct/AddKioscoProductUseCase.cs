using Application.DTOs._01_Common;
using Application.DTOs.KioscoProduct;
using Application.Entities;
using Application.Factories;
using Application.Interfaces._01_Common;
using AutoMapper;

namespace Application.UseCases.KioscoProduct
{
    public class AddKioscoProductUseCase
    {
        private readonly IAddRepo<KioscoProductEntity> _addKioscoProductRepo;
        private readonly IGetByIdComposedRepo<KioscoProductEntity> _getByIdComposedRepo;
        private readonly IGetByIdRepo<KioscoEntity> _getByIdKioscoRepo;
        private readonly IGetByIdRepo<ProductEntity> _getByIdProductRepo;
        private readonly IMapper _mapper;

        public AddKioscoProductUseCase(
            IAddRepo<KioscoProductEntity> addKioscoProductRepo,
            IGetByIdComposedRepo<KioscoProductEntity> getByIdComposedRepo,
            IGetByIdRepo<KioscoEntity> getByIdKioscoRepo,
            IGetByIdRepo<ProductEntity> getByIdProductRepo,
            IMapper mapper)
        {
            _addKioscoProductRepo = addKioscoProductRepo;
            _getByIdComposedRepo = getByIdComposedRepo;
            _getByIdKioscoRepo = getByIdKioscoRepo;
            _getByIdProductRepo = getByIdProductRepo;
            _mapper = mapper;
        }

        public async Task<AppResult> Execute(AddKioscoProductInput addKioscoProductInput)
        {
            KioscoProductEntity? kioscoProductEntityExist = await _getByIdComposedRepo
                .GetByIdComposedAsync(addKioscoProductInput.ProductId, addKioscoProductInput.KioscoId);
            if (kioscoProductEntityExist != null)
                return ResultFactory.CreateConflict("The kiosco product already exists");

            KioscoEntity? kioscoEntity = await _getByIdKioscoRepo.GetByIdAsync(addKioscoProductInput.KioscoId);
            if (kioscoEntity == null)
                return ResultFactory.CreateNotFound("The kiosco does not exist");

            ProductEntity? productEntity = await _getByIdProductRepo.GetByIdAsync(addKioscoProductInput.ProductId);
            if (productEntity == null)
                return ResultFactory.CreateNotFound("The product does not exist");

            KioscoProductEntity kioscoProductEntity = _mapper.Map<KioscoProductEntity>(addKioscoProductInput);
            kioscoProductEntity.KioscoSalePrice = productEntity.SalePrice;
            kioscoProductEntity.Stock = 0;

            bool isCreated = await _addKioscoProductRepo.AddAsync(kioscoProductEntity);

            if (!isCreated)
                return ResultFactory.CreateNotCreated("The product kiosco was not created");

            return ResultFactory.CreateCreated("The product kiosco was created", null);
        }
    }
}
