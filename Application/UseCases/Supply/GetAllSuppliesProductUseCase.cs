using Application.DTOs._01_Common;
using Application.DTOs.Supply;
using Application.Entities;
using Application.Factories;
using Application.Interfaces._01_Common;
using Application.Interfaces.Supply;
using AutoMapper;

namespace Application.UseCases.Supply
{
    public class GetAllSuppliesProductUseCase
    {
        private readonly IGetAllSupliesProductRepo _getAllSupliesProductRepo;
        private readonly IGetByIdRepo<ProductEntity> _getByIdRepo;
        private readonly IMapper _mapper;

        public GetAllSuppliesProductUseCase(
            IGetAllSupliesProductRepo getAllSupliesProductRepo,
            IGetByIdRepo<ProductEntity> getByIdRepo,
            IMapper mapper)
        {
            _getAllSupliesProductRepo = getAllSupliesProductRepo;
            _getByIdRepo = getByIdRepo;
            _mapper = mapper;
        }

        public async Task<AppResult> Execute(Guid productId)
        {
            ProductEntity? productEntity = await _getByIdRepo.GetByIdAsync(productId);
            if (productEntity == null)
                return ResultFactory.CreateNotFound("The product was not found");

            IEnumerable<SupplyProductEntity>? listSuppliesProductEntity = 
                await _getAllSupliesProductRepo.GetAllSupliesProductAsync(productId);

            if (listSuppliesProductEntity == null)
                return ResultFactory.CreateNotFound("There are no supplies");

            IEnumerable<GetSupplyOutput> listGetSuppliesOutput = listSuppliesProductEntity
                .Select(supplyEntity => _mapper.Map<GetSupplyOutput>(supplyEntity));

            return ResultFactory.CreateData("Sipplies", listGetSuppliesOutput);
        }
    }
}
