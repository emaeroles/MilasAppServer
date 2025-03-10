﻿using API.Response;
using Application.DTOs.Kiosco;
using Application.DTOs.ProductKiosco;
using Application.UseCases.Kiosco;
using Data.Repositories.ProductKiosco;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/kiosco-product")]
    [ApiController]
    public class ProductKioscoController : ControllerBase
    {
        [HttpGet("get-actives")]
        public async Task<IActionResult> GetSuppliesProducts(
            Guid kioscoId,
            ProductKioscoUseCases productKioscoUseCases)
        {
            var appResult = await productKioscoUseCases.GetAllProductsKioscoUseCase.Execute(kioscoId);
            return ResponseConverter.Execute(appResult);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddSupplyProduct(
            [FromBody] AddProductKioscoInput addProductKioscoInput,
            IValidator<AddProductKioscoInput> validator,
            ProductKioscoUseCases productKioscoUseCases)
        {
            var validResult = await validator.ValidateAsync(addProductKioscoInput);
            if (!validResult.IsValid)
                throw new ValidationException(validResult.Errors);

            var appResult = await productKioscoUseCases.AddProductKioscoUseCase.Execute(addProductKioscoInput);
            string url = $"";
            return ResponseConverter.Execute(appResult, url);
        }

        [HttpPatch("update-price")]
        public async Task<IActionResult> UpdateProductKioscoPrice(
            [FromBody] UpdateProductKioscoPriceIuput updateProductKioscoPriceIuput,
            IValidator<UpdateProductKioscoPriceIuput> validator,
            ProductKioscoUseCases productKioscoUseCases)
        {
            var validResult = await validator.ValidateAsync(updateProductKioscoPriceIuput);
            if (!validResult.IsValid)
                throw new ValidationException(validResult.Errors);

            var appResult = await productKioscoUseCases.UpdateProductKioscoPriceUseCase.Execute(updateProductKioscoPriceIuput);
            return ResponseConverter.Execute(appResult);
        }

        [HttpDelete("{kioscoId}/{productId}/delete")]
        public async Task<IActionResult> DeleteSuppliesProducts(
            Guid kioscoId,
            Guid productId,
            ProductKioscoUseCases productKioscoUseCases)
        {
            var appResult = await productKioscoUseCases.DeleteProductKioscoUseCase.Execute(productId, kioscoId);
            return ResponseConverter.Execute(appResult);
        }
    }
}
