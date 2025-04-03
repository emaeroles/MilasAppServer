using API.Response;
using Application.DTOs.User;
using Application.UseCases.User;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [Authorize]
        [HttpGet("get-actives")]
        public async Task<IActionResult> GetActivesUsers(
            UserUseCases userUseCases)
        {
            var appResult = await userUseCases.GetAllUsersUseCase.Execute(true);
            return ResponseConverter.Execute(appResult);
        }

        [Authorize]
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
            string url = $"/api/user/get-actives";
            return ResponseConverter.Execute(appResult, url);
        }

        [Authorize]
        [HttpPut("update")]
        public async Task<IActionResult> UpdateUser(
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

        [Authorize]
        [HttpPost("{userId}/toggle-active")]
        public async Task<IActionResult> ToggleActiveUser(
            Guid userId,
            UserUseCases userUseCases)
        {
            var appResult = await userUseCases.ToggleActiveUserUseCase.Execute(userId);
            return ResponseConverter.Execute(appResult);
        }
    }
}
