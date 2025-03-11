using Application.DTOs.Visit;
using FluentValidation;

namespace API.Validators.Visit
{
    public class AddVisitValid : AbstractValidator<AddVisitInput>
    {
        public AddVisitValid()
        {
            RuleFor(x => x.KioscoId)
                .NotEmpty();
            RuleFor(x => x.VisitDetails)
                .NotEmpty();
            RuleForEach(x => x.VisitDetails)
                .SetValidator(new AddVisitDetailValid());
        }
    }
}
