using Application.DTOs.Supply;
using FluentValidation;

namespace API.Validators.Supply
{
    public class AddUomValid : AbstractValidator<AddUomInput>
    {
        public AddUomValid() 
        {
            RuleFor(x => x.Unit)
                .NotEmpty()
                .MaximumLength(10);
        }
    }
}
