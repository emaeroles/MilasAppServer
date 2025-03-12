using API.Response;
using Application.DTOs.Kiosco;
using Application.UseCases.Kiosco;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/kiosco")]
    [ApiController]
    public class KioscoController : ControllerBase
    {
        [Authorize]
        [HttpGet("{userId}/get-actives")]
        public async Task<IActionResult> GetActivesKiosco(
            Guid userId,
            KioscoUseCases kioscoUseCases)
        {
            var appResult = await kioscoUseCases.GetAllKioscosUseCase.Execute(true, userId);
            return ResponseConverter.Execute(appResult);
        }

        [Authorize]
        [HttpGet("{userId}/get-inactives")]
        public async Task<IActionResult> GetInactivesKiosco(
            Guid userId,
            KioscoUseCases kioscoUseCases)
        {
            var appResult = await kioscoUseCases.GetAllKioscosUseCase.Execute(false, userId);
            return ResponseConverter.Execute(appResult);
        }

        [Authorize]
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

        [Authorize]
        [HttpPatch("update")]
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

        [Authorize]
        [HttpPatch("update-notes")]
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

        [Authorize]
        [HttpPatch("update-dubt")]
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

        [Authorize]
        [HttpPatch("update-order")]
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

        [Authorize]
        [HttpPost("{id}/toggle-is-changes")]
        public async Task<IActionResult> ToggleKioscoIsChanges(
            Guid id,
            KioscoUseCases kioscoUseCases)
        {
            var appResult = await kioscoUseCases.ToggleKioscoIsChangesUseCase.Execute(id);
            return ResponseConverter.Execute(appResult);
        }

        [Authorize]
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
