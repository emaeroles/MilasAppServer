using API.Response;
using Application.DTOs.User;
using Application.UseCases.User;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> AddUser([FromBody] AddUserInput addUserInput,
            UserUseCases userUseCases)
        {
            var appResult = await userUseCases.AddUserUseCase.Execute(addUserInput);
            string url = $"/api/get-actives";
            return ResponseConverter.Execute(appResult, url);
        }
    }
}
