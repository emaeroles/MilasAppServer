using API.Response;
using Application.DTOs.KioscoProduct;
using Data.Repositories.KioscoProduct;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/kiosco-product")]
    [ApiController]
    public class KioscoProductController : ControllerBase
    {
        [HttpGet("get-actives")]
        public async Task<IActionResult> GetKioscoProduct(
            Guid kioscoId,
            KioscoProductUseCases kioscoProductUseCases)
        {
            var appResult = await kioscoProductUseCases.GetAllKioscoProductsUseCase.Execute(kioscoId);
            return ResponseConverter.Execute(appResult);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddKioscoProduct(
            [FromBody] AddKioscoProductInput addKioscoProductInput,
            IValidator<AddKioscoProductInput> validator,
            KioscoProductUseCases kioscoProductUseCases)
        {
            var validResult = await validator.ValidateAsync(addKioscoProductInput);
            if (!validResult.IsValid)
                throw new ValidationException(validResult.Errors);

            var appResult = await kioscoProductUseCases.AddKioscoProductUseCase.Execute(addKioscoProductInput);
            string url = $"/api/kiosco-product/get-actives";
            return ResponseConverter.Execute(appResult, url);
        }

        [HttpPatch("update-price")]
        public async Task<IActionResult> UpdateKioscoProductPrice(
            [FromBody] UpdateKioscoProductPriceIuput updateKioscoProductPriceIuput,
            IValidator<UpdateKioscoProductPriceIuput> validator,
            KioscoProductUseCases kioscoProductUseCases)
        {
            var validResult = await validator.ValidateAsync(updateKioscoProductPriceIuput);
            if (!validResult.IsValid)
                throw new ValidationException(validResult.Errors);

            var appResult = await kioscoProductUseCases.UpdateKioscoProductPriceUseCase.Execute(updateKioscoProductPriceIuput);
            return ResponseConverter.Execute(appResult);
        }

        [HttpDelete("{kioscoId}/{productId}/delete")]
        public async Task<IActionResult> DeleteKioscoProduct(
            Guid kioscoId,
            Guid productId,
            KioscoProductUseCases kioscoProductUseCases)
        {
            var appResult = await kioscoProductUseCases.DeleteKioscoProductUseCase.Execute(productId, kioscoId);
            return ResponseConverter.Execute(appResult);
        }
    }
}
