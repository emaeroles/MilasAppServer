using Application.DTOs.Visit;
using FluentValidation;

namespace API.Validators.Visit
{
    public class AddVisitDetailValid : AbstractValidator<AddVisitDetailInput>
    {
        public AddVisitDetailValid()
        {
            RuleFor(x => x.ProductId)
                .NotEmpty();
            RuleFor(x => x.Has)
                .GreaterThanOrEqualTo(0);
            RuleFor(x => x.Leave)
                .GreaterThanOrEqualTo(0);
            RuleFor(x => x.Changes)
                .GreaterThanOrEqualTo(0);
        }
    }
}
