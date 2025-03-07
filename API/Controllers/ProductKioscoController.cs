using API.Response;
using Application.DTOs.ProductKiosco;
using Application.UseCases.SupplyProduct;
using Data.Repositories.ProductKiosco;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/kiosco-product")]
    [ApiController]
    public class ProductKioscoController : ControllerBase
    {
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
