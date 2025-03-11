using API.Response;
using Application.DTOs.Visit;
using Application.UseCases.Visit;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitController : ControllerBase
    {
        [HttpPost("add")]
        public async Task<IActionResult> AddKiosco(
            [FromBody] AddVisitInput addVisitInput,
            IValidator<AddVisitInput> validator,
            VisitUseCases visitUseCases)
        {
            var validResult = await validator.ValidateAsync(addVisitInput);
            if (!validResult.IsValid)
                throw new ValidationException(validResult.Errors);

            var appResult = await visitUseCases.AddVisitUseCase.Execute(addVisitInput);
            string url = "";
            return ResponseConverter.Execute(appResult, url);
        }
    }
}
