using Application.DTOs.Uom;
using FluentValidation;

namespace API.Validators.Uom
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
