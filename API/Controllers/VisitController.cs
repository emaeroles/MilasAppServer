using API.Response;
using Application.DTOs.Visit;
using Application.UseCases.Visit;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/visit")]
    [ApiController]
    public class VisitController : ControllerBase
    {
        [Authorize]
        [HttpGet("get-last-ten")]
        public async Task<IActionResult> GetLastTenVisits(
            //url: [HttpGet("{dateString}/{quantity/get")]
            //string dateString, 
            //int quantity,
            Guid kioscoId,
            VisitUseCases visitUseCases)
        {
            //var validator = new InlineValidator<string>();
            //validator.RuleFor(x => x)
            //    .Matches(@"^\d{4}-(0[1-9]|1[0-2])-(0[1-9]|[1-2][0-9]|3[0-1])$")
            //    .WithMessage("The date must be a string in the format yyyy-MM-dd.");

            //var validResult = await validator.ValidateAsync(dateString);
            //if (!validResult.IsValid)
            //    throw new ValidationException(validResult.Errors);

            //DateOnly date = DateOnly.Parse(dateString);

            DateTime dateTime = DateTime.Now;
            DateOnly dateOnly = new DateOnly(dateTime.Year, dateTime.Month, dateTime.Day);

            int quantity = 10;

            var appResult = await visitUseCases.GetVisitsUseCase.Execute(kioscoId, dateOnly, quantity);
            return ResponseConverter.Execute(appResult);
        }

        [Authorize]
        [HttpPost("add")]
        public async Task<IActionResult> AddVisit(
            [FromBody] AddVisitInput addVisitInput,
            IValidator<AddVisitInput> validator,
            VisitUseCases visitUseCases)
        {
            var validResult = await validator.ValidateAsync(addVisitInput);
            if (!validResult.IsValid)
                throw new ValidationException(validResult.Errors);

            var appResult = await visitUseCases.AddVisitUseCase.Execute(addVisitInput);
            string url = "/api/visit/get-last-ten";
            return ResponseConverter.Execute(appResult, url);
        }
    }
}
