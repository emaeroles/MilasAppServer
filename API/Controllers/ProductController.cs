﻿using API.Response;
using Application.DTOs.Product;
using Application.UseCases.Product;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet("get-actives")]
        public async Task<IActionResult> GetActivesKiosco(
            ProductUseCases productUseCases)
        {
            var appResult = await productUseCases.GetAllProductsUseCase.Execute(true);
            return ResponseConverter.Execute(appResult);
        }

        [HttpGet("get-inactives")]
        public async Task<IActionResult> GetInactivesKiosco(
            ProductUseCases productUseCases)
        {
            var appResult = await productUseCases.GetAllProductsUseCase.Execute(false);
            return ResponseConverter.Execute(appResult);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddProduct(
            [FromBody] AddProductInput addProductInput,
            IValidator<AddProductInput> validator,
            ProductUseCases productUseCases)
        {
            var validResult = await validator.ValidateAsync(addProductInput);
            if (!validResult.IsValid)
                throw new ValidationException(validResult.Errors);

            var appResult = await productUseCases.AddProductUseCase.Execute(addProductInput);
            string url = $"/api/product/get-actives";
            return ResponseConverter.Execute(appResult, url);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateSupply(
           [FromBody] UpdateProductInput updateProductInput,
           IValidator<UpdateProductInput> validator,
           ProductUseCases productUseCases)
        {
            var validResult = await validator.ValidateAsync(updateProductInput);
            if (!validResult.IsValid)
                throw new ValidationException(validResult.Errors);

            var appResult = await productUseCases.UpdateProductUseCase.Execute(updateProductInput);
            return ResponseConverter.Execute(appResult);
        }
    }
}
