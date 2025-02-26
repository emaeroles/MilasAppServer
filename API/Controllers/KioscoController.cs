using API.Response;
using Application.DTOs.Kiosco;
using Application.DTOs.User;
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
            KioscoUseCases kioscoUseCases)
        {
            var appResult = await kioscoUseCases.AddKioscoUseCase.Execute(addKioscoInput);
            string url = $"/api/get-actives";
            return ResponseConverter.Execute(appResult, url);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateKiosco(
            [FromBody] UpdateKioscoInput updateKioscoInput,
            KioscoUseCases kioscoUseCases)
        {
            var appResult = await kioscoUseCases.UpdateKioscoUseCase.Execute(updateKioscoInput);
            return ResponseConverter.Execute(appResult);
        }

        [HttpPut("update-notes")]
        public async Task<IActionResult> UpdateNotes(
            [FromBody] UpdateKioscoNotesInput updateKioscoNotesInput,
            KioscoUseCases kioscoUseCases)
        {
            var appResult = await kioscoUseCases.UpdateNotesUseCase.Execute(updateKioscoNotesInput);
            return ResponseConverter.Execute(appResult);
        }

        [HttpPut("update-dubt")]
        public async Task<IActionResult> UpdateDubt(
            [FromBody] UpdateKioscoDubtInput updateKioscoDubtInput,
            KioscoUseCases kioscoUseCases)
        {
            var appResult = await kioscoUseCases.UpdateDubtUseCase.Execute(updateKioscoDubtInput);
            return ResponseConverter.Execute(appResult);
        }

        [HttpPut("update-order")]
        public async Task<IActionResult> UpdateOrder(
            [FromBody] UpdateKioscoOrderInput updateKioscoOrderInput,
            KioscoUseCases kioscoUseCases)
        {
            var appResult = await kioscoUseCases.UpdateOrderUseCase.Execute(updateKioscoOrderInput);
            return ResponseConverter.Execute(appResult);
        }

        [HttpPost("{id}/toggle-is-changes")]
        public async Task<IActionResult> ToggleIsChangesKiosco(
            int id,
            KioscoUseCases kioscoUseCases)
        {
            var appResult = await kioscoUseCases.ToggleIsChangesUseCase.Execute(id);
            return ResponseConverter.Execute(appResult);
        }

        [HttpPost("{id}/toggle-active")]
        public async Task<IActionResult> ToggleActiveKiosco(
            int id,
            KioscoUseCases kioscoUseCases)
        {
            var appResult = await kioscoUseCases.ToggleActiveKioscoUseCase.Execute(id);
            return ResponseConverter.Execute(appResult);
        }
    }
}
