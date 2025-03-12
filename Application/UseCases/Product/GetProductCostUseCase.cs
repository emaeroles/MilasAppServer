using Application.DTOs._01_Common;
using Application.DTOs.Product;
using Application.Entities;
using Application.Factories;
using Application.Interfaces.ProductSupply;

namespace Application.UseCases.Product
{
    public class GetProductCostUseCase
    {
        private readonly IGetAllProductSuppliesRepo _getAllProductSuppliesRepo;

        public GetProductCostUseCase(IGetAllProductSuppliesRepo getAllProductSuppliesRepo)
        {
            _getAllProductSuppliesRepo = getAllProductSuppliesRepo;
        }

        public async Task<AppResult> Execute(Guid productId)
        {
            IEnumerable<ProductSupplyEntity>? listSuppliesProductEntity =
                await _getAllProductSuppliesRepo.GetAllProductSuppliesAsync(productId);

            if (listSuppliesProductEntity == null)
                return ResultFactory.CreateNotFound("There are no supplies");

            GetProductCostOutput getProductCostOutput = new GetProductCostOutput();

            getProductCostOutput.ProductCost = listSuppliesProductEntity
                .Sum(s => ((decimal)s.Quantity / s.Yeild) * s.CostPrice / (decimal)s.Quantity);

            return ResultFactory.CreateData("Product cost", getProductCostOutput);
        }
    }
}
