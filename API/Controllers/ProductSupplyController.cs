using API.Response;
using Application.DTOs.ProductSupply;
using Application.UseCases.ProductSupply;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/product-supply")]
    [ApiController]
    public class ProductSupplyController : ControllerBase
    {
        [HttpGet("get-actives")]
        public async Task<IActionResult> GetProductSupplies(
            Guid productId,
            ProductSupplyUseCases productSupplyUseCases)
        {
            var appResult = await productSupplyUseCases.GetAllProductSuppliesUseCase.Execute(productId);
            return ResponseConverter.Execute(appResult);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddProductSupply(
            [FromBody] AddProductSupplyInput addProductSupplyInput,
            IValidator<AddProductSupplyInput> validator,
            ProductSupplyUseCases productSupplyUseCases)
        {
            var validResult = await validator.ValidateAsync(addProductSupplyInput);
            if (!validResult.IsValid)
                throw new ValidationException(validResult.Errors);

            var appResult = await productSupplyUseCases.AddProductSupplyUseCase.Execute(addProductSupplyInput);
            string url = $"/api/supplies/product/get-actives";
            return ResponseConverter.Execute(appResult, url);
        }

        [HttpDelete("{productId}/{supplyId}/delete")]
        public async Task<IActionResult> DeleteProductSupply(
            Guid productId,
            Guid supplyId,
            ProductSupplyUseCases productSupplyUseCases)
        {
            var appResult = await productSupplyUseCases.DeleteProductSupplyUseCase.Execute(supplyId, productId);
            return ResponseConverter.Execute(appResult);
        }
    }
}
