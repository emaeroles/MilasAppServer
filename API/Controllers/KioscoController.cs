using API.Response;
using Application.DTOs.Kiosco;
using Application.UseCases.Kiosco;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/kiosco")]
    [ApiController]
    public class KioscoController : ControllerBase
    {
        [HttpGet("get-actives")]
        public async Task<IActionResult> GetActivesKiosco(
            KioscoUseCases kioscoUseCases)
        {
            var appResult = await kioscoUseCases.GetAllKioscosUseCase.Execute(true);
            return ResponseConverter.Execute(appResult);
        }

        [HttpGet("get-inactives")]
        public async Task<IActionResult> GetInactivesKiosco(
            KioscoUseCases kioscoUseCases)
        {
            var appResult = await kioscoUseCases.GetAllKioscosUseCase.Execute(false);
            return ResponseConverter.Execute(appResult);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddKiosco(
            [FromBody] AddKioscoInput addKioscoInput,
            IValidator<AddKioscoInput> validator,
            KioscoUseCases kioscoUseCases)
        {
            var validResult = await validator.ValidateAsync(addKioscoInput);
            if (!validResult.IsValid)
                throw new ValidationException(validResult.Errors);

            var appResult = await kioscoUseCases.AddKioscoUseCase.Execute(addKioscoInput);
            string url = $"/api/kiosco/get-actives";
            return ResponseConverter.Execute(appResult, url);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateKiosco(
            [FromBody] UpdateKioscoInput updateKioscoInput,
            IValidator<UpdateKioscoInput> validator,
            KioscoUseCases kioscoUseCases)
        {
            var validResult = await validator.ValidateAsync(updateKioscoInput);
            if (!validResult.IsValid)
                throw new ValidationException(validResult.Errors);

            var appResult = await kioscoUseCases.UpdateKioscoUseCase.Execute(updateKioscoInput);
            return ResponseConverter.Execute(appResult);
        }

        [HttpPut("update-notes")]
        public async Task<IActionResult> UpdateKioscoNotes(
            [FromBody] UpdateKioscoNotesInput updateKioscoNotesInput,
            IValidator<UpdateKioscoNotesInput> validator,
            KioscoUseCases kioscoUseCases)
        {
            var validResult = await validator.ValidateAsync(updateKioscoNotesInput);
            if (!validResult.IsValid)
                throw new ValidationException(validResult.Errors);

            var appResult = await kioscoUseCases.UpdateKioscoNotesUseCase.Execute(updateKioscoNotesInput);
            return ResponseConverter.Execute(appResult);
        }

        [HttpPut("update-dubt")]
        public async Task<IActionResult> UpdateKioscoDubt(
            [FromBody] UpdateKioscoDubtInput updateKioscoDubtInput,
            IValidator<UpdateKioscoDubtInput> validator,
            KioscoUseCases kioscoUseCases)
        {
            var validResult = await validator.ValidateAsync(updateKioscoDubtInput);
            if (!validResult.IsValid)
                throw new ValidationException(validResult.Errors);

            var appResult = await kioscoUseCases.UpdateKioscoDubtUseCase.Execute(updateKioscoDubtInput);
            return ResponseConverter.Execute(appResult);
        }

        [HttpPut("update-order")]
        public async Task<IActionResult> UpdateKioscoOrder(
            [FromBody] UpdateKioscoOrderInput updateKioscoOrderInput,
            IValidator<UpdateKioscoOrderInput> validator,
            KioscoUseCases kioscoUseCases)
        {
            var validResult = await validator.ValidateAsync(updateKioscoOrderInput);
            if (!validResult.IsValid)
                throw new ValidationException(validResult.Errors);

            var appResult = await kioscoUseCases.UpdateKioscoOrderUseCase.Execute(updateKioscoOrderInput);
            return ResponseConverter.Execute(appResult);
        }

        [HttpPost("{id}/update-is-changes")]
        public async Task<IActionResult> UpdateKioscoIsChanges(
            Guid id,
            KioscoUseCases kioscoUseCases)
        {
            var appResult = await kioscoUseCases.UpdateKioscoIsChangesUseCase.Execute(id);
            return ResponseConverter.Execute(appResult);
        }

        [HttpPost("{id}/toggle-active")]
        public async Task<IActionResult> ToggleActiveKiosco(
            Guid id,
            KioscoUseCases kioscoUseCases)
        {
            var appResult = await kioscoUseCases.ToggleActiveKioscoUseCase.Execute(id);
            return ResponseConverter.Execute(appResult);
        }
    }
}
