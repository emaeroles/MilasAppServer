using Application.DTOs._01_Common;
using Application.DTOs.Supply;
using Application.Entities;
using Application.Factories;
using Application.Interfaces._01_Common;
using Application.Interfaces.ProductSupply;
using AutoMapper;

namespace Application.UseCases.ProductSupply
{
    public class GetAllProductSuppliesUseCase
    {
        private readonly IGetAllProductSuppliesRepo _getAllProductSuppliesRepo;
        private readonly IGetByIdRepo<ProductEntity> _getByIdRepo;
        private readonly IMapper _mapper;

        public GetAllProductSuppliesUseCase(
            IGetAllProductSuppliesRepo getAllProductSuppliesRepo,
            IGetByIdRepo<ProductEntity> getByIdRepo,
            IMapper mapper)
        {
            _getAllProductSuppliesRepo = getAllProductSuppliesRepo;
            _getByIdRepo = getByIdRepo;
            _mapper = mapper;
        }

        public async Task<AppResult> Execute(Guid productId)
        {
            ProductEntity? productEntity = await _getByIdRepo.GetByIdAsync(productId);
            if (productEntity == null)
                return ResultFactory.CreateNotFound("The product was not found");

            IEnumerable<ProductSupplyEntity>? listSuppliesProductEntity = 
                await _getAllProductSuppliesRepo.GetAllProductSuppliesAsync(productId);

            if (listSuppliesProductEntity == null)
                return ResultFactory.CreateNotFound("There are no supplies");

            IEnumerable<GetSupplyOutput> listGetSuppliesOutput = listSuppliesProductEntity
                .Select(supplyEntity => _mapper.Map<GetSupplyOutput>(supplyEntity));

            return ResultFactory.CreateData("Sipplies", listGetSuppliesOutput);
        }
    }
}
