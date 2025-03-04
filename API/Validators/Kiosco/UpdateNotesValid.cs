using Application.DTOs.Kiosco;
using FluentValidation;

namespace API.Validators.Kiosco
{
    public class UpdateNotesValid : AbstractValidator<UpdateKioscoNotesInput>
    {
        public UpdateNotesValid() 
        {
            RuleFor(x => x.Id)
                .NotEmpty();
            RuleFor(x => x.Notes)
                .NotEmpty()
                .MaximumLength(995);
        }
    }
}
