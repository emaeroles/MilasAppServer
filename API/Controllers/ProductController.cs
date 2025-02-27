using API.Response;
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
    }
}
