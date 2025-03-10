using API.Response;
using Application.DTOs.Supply;
using Application.UseCases.Supply;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/supply")]
    [ApiController]
    public class SuppliesController : ControllerBase
    {
        [HttpGet("get-actives")]
        public async Task<IActionResult> GetActivesSupplies(
            SupplyUseCases supplyUseCases)
        {
            var appResult = await supplyUseCases.GetAllSuppliesUseCase.Execute(true);
            return ResponseConverter.Execute(appResult);
        }

        [HttpGet("get-inactives")]
        public async Task<IActionResult> GetInactivesSupplies(
            SupplyUseCases supplyUseCases)
        {
            var appResult = await supplyUseCases.GetAllSuppliesUseCase.Execute(false);
            return ResponseConverter.Execute(appResult);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddSupply(
            [FromBody] AddSupplyInput addSupplyInput,
            IValidator<AddSupplyInput> validator,
            SupplyUseCases supplyUseCases)
        {
            var validResult = await validator.ValidateAsync(addSupplyInput);
            if (!validResult.IsValid)
                throw new ValidationException(validResult.Errors);

            var appResult = await supplyUseCases.AddSupplyUseCase.Execute(addSupplyInput);
            string url = $"/api/supplies/get-actives";
            return ResponseConverter.Execute(appResult, url);
        }

        [HttpPatch("update")]
        public async Task<IActionResult> UpdateSupply(
            [FromBody] UpdateSupplyInput updateSupplyInput,
            IValidator<UpdateSupplyInput> validator,
            SupplyUseCases supplyUseCases)
        {
            var validResult = await validator.ValidateAsync(updateSupplyInput);
            if (!validResult.IsValid)
                throw new ValidationException(validResult.Errors);

            var appResult = await supplyUseCases.UpdateSupplyUseCase.Execute(updateSupplyInput);
            return ResponseConverter.Execute(appResult);
        }

        [HttpPost("{id}/toggle-active")]
        public async Task<IActionResult> ToggleActiveSupply(
            Guid id,
            SupplyUseCases supplyUseCases)
        {
            var appResult = await supplyUseCases.ToggleActiveSupplyUseCase.Execute(id);
            return ResponseConverter.Execute(appResult);
        }  
    }
}
