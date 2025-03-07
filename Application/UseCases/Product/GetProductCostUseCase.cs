﻿using Application.DTOs._01_Common;
using Application.DTOs.Product;
using Application.Entities;
using Application.Factories;
using Application.Interfaces.SupplyProduct;

namespace Application.UseCases.Product
{
    public class GetProductCostUseCase
    {
        private readonly IGetAllSuppliesProductRepo _getAllSupliesProductRepo;

        public GetProductCostUseCase(IGetAllSuppliesProductRepo getAllSupliesProductRepo)
        {
            _getAllSupliesProductRepo = getAllSupliesProductRepo;
        }

        public async Task<AppResult> Execute(Guid productId)
        {
            IEnumerable<SupplyProductEntity>? listSuppliesProductEntity =
                await _getAllSupliesProductRepo.GetAllSupliesProductAsync(productId);

            if (listSuppliesProductEntity == null)
                return ResultFactory.CreateNotFound("There are no supplies");

            GetProductCostOutput getProductCostOutput = new GetProductCostOutput();

            getProductCostOutput.ProductCost = listSuppliesProductEntity
                .Sum(s => ((decimal)s.Quantity / s.Yeild) * s.CostPrice / (decimal)s.Quantity);

            return ResultFactory.CreateData("Product cost", getProductCostOutput);
        }
    }
}
