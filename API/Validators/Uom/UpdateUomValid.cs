using Application.DTOs.Uom;
using FluentValidation;

namespace API.Validators.Uom
{
    public class UpdateUomValid : AbstractValidator<UpdateUomInput>
    {
        public UpdateUomValid()
        {
            RuleFor(x => x.Id)
                .NotEmpty();
            RuleFor(x => x.Unit)
                .NotEmpty()
                .MaximumLength(10);
        }  
    }
}
