using Application.DTOs.Supply;
using FluentValidation;

namespace API.Validators.Supply
{
    public class UpdateUomValid : AbstractValidator<UpdateUomInput>
    {
        public UpdateUomValid()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0);
            RuleFor(x => x.Unit)
                .NotEmpty()
                .MaximumLength(10);
        }  
    }
}
