using API.Response;
using Application.DTOs.Uom;
using Application.UseCases.Uom;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/unit-of-measure")]
    [ApiController]
    public class UomController : ControllerBase
    {
        [Authorize]
        [HttpGet("get-actives")]
        public async Task<IActionResult> GetActivesUom(
            UomUseCases uomUseCases)
        {
            var appResult = await uomUseCases.GetAllUomsUseCase.Execute(true);
            return ResponseConverter.Execute(appResult);
        }

        [Authorize]
        [HttpGet("get-inactives")]
        public async Task<IActionResult> GetInactivesUom(
            UomUseCases uomUseCases)
        {
            var appResult = await uomUseCases.GetAllUomsUseCase.Execute(false);
            return ResponseConverter.Execute(appResult);
        }

        [Authorize]
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
            string url = $"/api/unit-of-measure/get-actives";
            return ResponseConverter.Execute(appResult, url);
        }

        [Authorize]
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

        [Authorize]
        [HttpPost("{uomId}/toggle-active")]
        public async Task<IActionResult> ToggleActiveUom(
            Guid uomId,
            UomUseCases uomUseCases)
        {
            var appResult = await uomUseCases.ToggleActiveUomUseCase.Execute(uomId);
            return ResponseConverter.Execute(appResult);
        }
    }
}
