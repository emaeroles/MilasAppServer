using API.Response;
using Application.DTOs.User;
using Application.UseCases.User;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace API.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet("get-actives")]
        public async Task<IActionResult> GetActivesUsers(
            UserUseCases userUseCases)
        {
            var appResult = await userUseCases.GetAllUsersUseCase.Execute(true);
            return ResponseConverter.Execute(appResult);
        }

        [HttpGet("get-inactives")]
        public async Task<IActionResult> GetInactivesUsers(
            UserUseCases userUseCases)
        {
            var appResult = await userUseCases.GetAllUsersUseCase.Execute(false);
            return ResponseConverter.Execute(appResult);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddUser(
            [FromBody] AddUserInput addUserInput,
            IValidator<AddUserInput> validator,
            UserUseCases userUseCases)
        {
            var validResult = await validator.ValidateAsync(addUserInput);
            if (!validResult.IsValid)
                throw new ValidationException(validResult.Errors);

            var appResult = await userUseCases.AddUserUseCase.Execute(addUserInput);
            string url = $"/api/get-actives";
            return ResponseConverter.Execute(appResult, url);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateKiosco(
            [FromBody] UpdateUserInput updateUserInput,
            IValidator<UpdateUserInput> validator,
            UserUseCases userUseCases)
        {
            var validResult = await validator.ValidateAsync(updateUserInput);
            if (!validResult.IsValid)
                throw new ValidationException(validResult.Errors);

            var appResult = await userUseCases.UpdateUserUseCase.Execute(updateUserInput);
            return ResponseConverter.Execute(appResult);
        }

        [HttpPost("{id}/toggle-active")]
        public async Task<IActionResult> ToggleActiveKiosco(
            int id,
            UserUseCases userUseCases)
        {
            var appResult = await userUseCases.ToggleActiveUserUseCase.Execute(id);
            return ResponseConverter.Execute(appResult);
        }
    }
}
