using API.Response;
using Application.DTOs.Auth;
using Application.UseCases.Auth;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost("user")]
        public async Task<IActionResult> AuthUser(
            [FromBody] AuthInput authInput,
            IValidator<AuthInput> validator,
            AuthUseCase authUseCase)
        {
            var validResult = await validator.ValidateAsync(authInput);
            if (!validResult.IsValid)
                throw new ValidationException(validResult.Errors);

            var appResult = await authUseCase.Execute(authInput);
            return ResponseConverter.Execute(appResult);
        }
    }
}
