using API.Response;
using Application.DTOs.Uom;
using Application.UseCases.Supply;
using Application.UseCases.Uom;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/unit-of-measure")]
    [ApiController]
    public class UomController : ControllerBase
    {
        [HttpGet("get-actives")]
        public async Task<IActionResult> GetActivesUom(
            UomUseCases uomUseCases)
        {
            var appResult = await uomUseCases.GetAllUomsUseCase.Execute(true);
            return ResponseConverter.Execute(appResult);
        }

        [HttpGet("get-inactives")]
        public async Task<IActionResult> GetInactivesUom(
            UomUseCases uomUseCases)
        {
            var appResult = await uomUseCases.GetAllUomsUseCase.Execute(false);
            return ResponseConverter.Execute(appResult);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddUom(
            [FromBody] AddUomInput addUomInput,
            IValidator<AddUomInput> validator,
            UomUseCases uomUseCases)
        {
            var validResult = await validator.ValidateAsync(addUomInput);
            if (!validResult.IsValid)
                throw new ValidationException(validResult.Errors);

            var appResult = await uomUseCases.AddUomUseCase.Execute(addUomInput);
            string url = $"/api/supplies/get-actives";
            return ResponseConverter.Execute(appResult, url);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateUom(
            [FromBody] UpdateUomInput updateUomInput,
            IValidator<UpdateUomInput> validator,
            UomUseCases uomUseCases)
        {
            var validResult = await validator.ValidateAsync(updateUomInput);
            if (!validResult.IsValid)
                throw new ValidationException(validResult.Errors);

            var appResult = await uomUseCases.UpdateUomUseCase.Execute(updateUomInput);
            return ResponseConverter.Execute(appResult);
        }

        [HttpPost("{id}/toggle-active")]
        public async Task<IActionResult> ToggleActiveUom(
            Guid id,
            UomUseCases uomUseCases)
        {
            var appResult = await uomUseCases.ToggleActiveUomUseCase.Execute(id);
            return ResponseConverter.Execute(appResult);
        }
    }
}
