using Application.DTOs.Kiosco;
using FluentValidation;

namespace API.Validators.Kiosco
{
    public class UpdateDubtValid : AbstractValidator<UpdateKioscoDubtInput>
    {
        public UpdateDubtValid() 
        {
            RuleFor(x => x.Id)
                .NotEmpty();
            RuleFor(x => x.Dubt)
                .GreaterThanOrEqualTo(0);
        }
    }
}
