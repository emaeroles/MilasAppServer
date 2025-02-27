using API.Response;
using Application.DTOs.Supply;
using Application.UseCases.Supply;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/supplies")]
    [ApiController]
    public class SuppliesController : ControllerBase
    {
        [HttpGet("uom/get-actives")]
        public async Task<IActionResult> GetActivesUsers(
            SuppliesUseCases supliesUseCases)
        {
            var appResult = await supliesUseCases.GetAllUomsUseCase.Execute(true);
            return ResponseConverter.Execute(appResult);
        }

        [HttpGet("uom/get-inactives")]
        public async Task<IActionResult> GetInactivesUsers(
            SuppliesUseCases supliesUseCases)
        {
            var appResult = await supliesUseCases.GetAllUomsUseCase.Execute(false);
            return ResponseConverter.Execute(appResult);
        }

        [HttpPost("uom/add")]
        public async Task<IActionResult> AddUser(
            [FromBody] AddUomInput addUomInput,
            //IValidator<AddUserInput> validator,
            SuppliesUseCases supliesUseCases)
        {
            //var validResult = await validator.ValidateAsync(addUserInput);
            //if (!validResult.IsValid)
            //    throw new ValidationException(validResult.Errors);

            var appResult = await supliesUseCases.AddUomUseCase.Execute(addUomInput);
            string url = $"/api/supplies/get-actives";
            return ResponseConverter.Execute(appResult, url);
        }

        [HttpPut("uom/update")]
        public async Task<IActionResult> UpdateUser(
            [FromBody] UpdateUomInput updateUomInput,
            //IValidator<UpdateUserInput> validator,
            SuppliesUseCases supliesUseCases)
        {
            //var validResult = await validator.ValidateAsync(updateUserInput);
            //if (!validResult.IsValid)
            //    throw new ValidationException(validResult.Errors);

            var appResult = await supliesUseCases.UpdateUomUseCase.Execute(updateUomInput);
            return ResponseConverter.Execute(appResult);
        }

        [HttpPost("uom/{id}/toggle-active")]
        public async Task<IActionResult> ToggleActiveUser(
            int id,
            SuppliesUseCases supliesUseCases)
        {
            var appResult = await supliesUseCases.ToggleActiveUomUseCase.Execute(id);
            return ResponseConverter.Execute(appResult);
        }
    }
}
