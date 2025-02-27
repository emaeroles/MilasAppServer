using API.Response;
using Application.DTOs.Supply;
using Application.UseCases.Supply;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/supplies")]
    [ApiController]
    public class SuppliesController : ControllerBase
    {
        [HttpGet("get-actives")]
        public async Task<IActionResult> GetActivesSupplies(
            SupplyUseCases supliesUseCases)
        {
            var appResult = await supliesUseCases.GetAllSuppliesUseCase.Execute(true);
            return ResponseConverter.Execute(appResult);
        }

        [HttpGet("get-inactives")]
        public async Task<IActionResult> GetInactivesSupplies(
            SupplyUseCases supliesUseCases)
        {
            var appResult = await supliesUseCases.GetAllSuppliesUseCase.Execute(false);
            return ResponseConverter.Execute(appResult);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddSupply(
            [FromBody] AddSupplyInput addSupplyInput,
            IValidator<AddSupplyInput> validator,
            SupplyUseCases supliesUseCases)
        {
            var validResult = await validator.ValidateAsync(addSupplyInput);
            if (!validResult.IsValid)
                throw new ValidationException(validResult.Errors);

            var appResult = await supliesUseCases.AddSupplyUseCase.Execute(addSupplyInput);
            string url = $"/api/supplies/get-actives";
            return ResponseConverter.Execute(appResult, url);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateSupply(
            [FromBody] UpdateSupplyInput updateSupplyInput,
            IValidator<UpdateSupplyInput> validator,
            SupplyUseCases supliesUseCases)
        {
            var validResult = await validator.ValidateAsync(updateSupplyInput);
            if (!validResult.IsValid)
                throw new ValidationException(validResult.Errors);

            var appResult = await supliesUseCases.UpdateSupplyUseCase.Execute(updateSupplyInput);
            return ResponseConverter.Execute(appResult);
        }

        [HttpPost("{id}/toggle-active")]
        public async Task<IActionResult> ToggleActiveSupply(
            int id,
            SupplyUseCases supliesUseCases)
        {
            var appResult = await supliesUseCases.ToggleActiveSupplyUseCase.Execute(id);
            return ResponseConverter.Execute(appResult);
        }

        // ==========================================================================

        [HttpGet("uom/get-actives")]
        public async Task<IActionResult> GetActivesUom(
            SupplyUseCases supliesUseCases)
        {
            var appResult = await supliesUseCases.GetAllUomsUseCase.Execute(true);
            return ResponseConverter.Execute(appResult);
        }

        [HttpGet("uom/get-inactives")]
        public async Task<IActionResult> GetInactivesUom(
            SupplyUseCases supliesUseCases)
        {
            var appResult = await supliesUseCases.GetAllUomsUseCase.Execute(false);
            return ResponseConverter.Execute(appResult);
        }

        [HttpPost("uom/add")]
        public async Task<IActionResult> AddUom(
            [FromBody] AddUomInput addUomInput,
            IValidator<AddUomInput> validator,
            SupplyUseCases supliesUseCases)
        {
            var validResult = await validator.ValidateAsync(addUomInput);
            if (!validResult.IsValid)
                throw new ValidationException(validResult.Errors);

            var appResult = await supliesUseCases.AddUomUseCase.Execute(addUomInput);
            string url = $"/api/supplies/get-actives";
            return ResponseConverter.Execute(appResult, url);
        }

        [HttpPut("uom/update")]
        public async Task<IActionResult> UpdateUom(
            [FromBody] UpdateUomInput updateUomInput,
            IValidator<UpdateUomInput> validator,
            SupplyUseCases supliesUseCases)
        {
            var validResult = await validator.ValidateAsync(updateUomInput);
            if (!validResult.IsValid)
                throw new ValidationException(validResult.Errors);

            var appResult = await supliesUseCases.UpdateUomUseCase.Execute(updateUomInput);
            return ResponseConverter.Execute(appResult);
        }

        [HttpPost("uom/{id}/toggle-active")]
        public async Task<IActionResult> ToggleActiveUom(
            int id,
            SupplyUseCases supliesUseCases)
        {
            var appResult = await supliesUseCases.ToggleActiveUomUseCase.Execute(id);
            return ResponseConverter.Execute(appResult);
        }
    }
}
