using Application.DTOs._01_Common;
using Application.DTOs.ProductKiosco;
using Application.Entities;
using Application.Factories;
using Application.Interfaces._01_Common;
using Application.Interfaces.ProductKiosco;
using AutoMapper;

namespace Application.UseCases.ProductKiosco
{
    public class GetAllProductsKioscoUseCase
    {
        private readonly IGetAllProductsKioscoRepo _getAllProductsKioscoRepo;
        private readonly IGetByIdRepo<KioscoEntity> _getByIdRepo;
        private readonly IMapper _mapper;

        public GetAllProductsKioscoUseCase(
            IGetAllProductsKioscoRepo getAllProductsKioscoRepo,
            IGetByIdRepo<KioscoEntity> getByIdRepo,
            IMapper mapper)
        {
            _getAllProductsKioscoRepo = getAllProductsKioscoRepo;
            _getByIdRepo = getByIdRepo;
            _mapper = mapper;
        }

        public async Task<AppResult> Execute(Guid kioscoId)
        {
            KioscoEntity? kioscoEntity = await _getByIdRepo.GetByIdAsync(kioscoId);
            if (kioscoEntity == null)
                return ResultFactory.CreateNotFound("The kiosco was not found");

            IEnumerable<ProductKioscoEntity>? listProductsKioscoEntity =
                await _getAllProductsKioscoRepo.GetAllProductsKioscoAsync(kioscoId);

            if (listProductsKioscoEntity == null)
                return ResultFactory.CreateNotFound("There are no products");

            IEnumerable<GetProductKioscoOutput> listGetProductKioscoOutput = listProductsKioscoEntity
                .Select(supplyEntity => _mapper.Map<GetProductKioscoOutput>(supplyEntity));

            return ResultFactory.CreateData("Products", listGetProductKioscoOutput);
        }
    }
}
