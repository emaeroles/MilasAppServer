using API.Response;
using Application.DTOs.SupplyProduct;
using Application.UseCases.SupplyProduct;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/product-supply")]
    [ApiController]
    public class SupplyProductController : ControllerBase
    {
        [HttpGet("get-actives")]
        public async Task<IActionResult> GetSuppliesProducts(
            Guid productId,
            SupplyProductUseCases supplyProductUseCases)
        {
            var appResult = await supplyProductUseCases.GetAllSuppliesProductUseCase.Execute(productId);
            return ResponseConverter.Execute(appResult);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddSupplyProduct(
            [FromBody] AddSupplyProductInput addSupplyProductInput,
            IValidator<AddSupplyProductInput> validator,
            SupplyProductUseCases supplyProductUseCases)
        {
            var validResult = await validator.ValidateAsync(addSupplyProductInput);
            if (!validResult.IsValid)
                throw new ValidationException(validResult.Errors);

            var appResult = await supplyProductUseCases.AddSupplyProductUseCase.Execute(addSupplyProductInput);
            string url = $"/api/supplies/product/get-actives";
            return ResponseConverter.Execute(appResult, url);
        }

        [HttpDelete("{productId}/{supplyId}/delete")]
        public async Task<IActionResult> DeleteSuppliesProducts(
            Guid productId,
            Guid supplyId,
            SupplyProductUseCases supplyProductUseCases)
        {
            var appResult = await supplyProductUseCases.DeleteSupplyProductUseCase.Execute(supplyId, productId);
            return ResponseConverter.Execute(appResult);
        }
    }
}
