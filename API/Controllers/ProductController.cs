using API.Response;
using Application.DTOs.Product;
using Application.UseCases.Product;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [Authorize]
        [HttpGet("get-actives")]
        public async Task<IActionResult> GetActivesProduct(
            ProductUseCases productUseCases)
        {
            var appResult = await productUseCases.GetAllProductsUseCase.Execute(true);
            return ResponseConverter.Execute(appResult);
        }

        [Authorize]
        [HttpGet("get-inactives")]
        public async Task<IActionResult> GetInactivesProduct(
            ProductUseCases productUseCases)
        {
            var appResult = await productUseCases.GetAllProductsUseCase.Execute(false);
            return ResponseConverter.Execute(appResult);
        }

        [Authorize]
        [HttpGet("{productId}/cost")]
        public async Task<IActionResult> GetProductCost(
            Guid productId,
            ProductUseCases productUseCases)
        {
            var appResult = await productUseCases.GetProductCostUseCase.Execute(productId);
            return ResponseConverter.Execute(appResult);
        }

        [Authorize]
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

        [Authorize]
        [HttpPatch("update")]
        public async Task<IActionResult> UpdateProduct(
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

        [Authorize]
        [HttpPost("{productId}/toggle-active")]
        public async Task<IActionResult> ToggleActiveProduct(
           Guid productId,
           ProductUseCases productUseCases)
        {
            var appResult = await productUseCases.ToggleActiveProductUseCase.Execute(productId);
            return ResponseConverter.Execute(appResult);
        }
    }
}
