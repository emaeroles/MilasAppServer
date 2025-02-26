using Application.DTOs.Kiosco;
using FluentValidation;

namespace API.Validators.Kiosco
{
    public class UpdateNotesValid : AbstractValidator<UpdateKioscoNotesInput>
    {
        public UpdateNotesValid() 
        {
            RuleFor(x => x.Id)
                .GreaterThan(0);
            RuleFor(x => x.Notes)
                .NotEmpty()
                .MaximumLength(995);
        }
    }
}
