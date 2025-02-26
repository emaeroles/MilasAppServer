using Application.DTOs.Kiosco;
using FluentValidation;

namespace API.Validators.Kiosco
{
    public class UpdateDubtValid : AbstractValidator<UpdateKioscoDubtInput>
    {
        public UpdateDubtValid() 
        {
            RuleFor(x => x.Id)
                .GreaterThan(0);
            RuleFor(x => x.Dubt)
                .GreaterThanOrEqualTo(0);
        }
    }
}
