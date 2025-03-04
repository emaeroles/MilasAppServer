using Application.DTOs.Kiosco;
using FluentValidation;

namespace API.Validators.Kiosco
{
    public class UpdateOrderValid : AbstractValidator<UpdateKioscoOrderInput>
    {
        public UpdateOrderValid()
        {
            RuleFor(x => x.Id)
                .NotEmpty();
            RuleFor(x => x.Order)
                .GreaterThanOrEqualTo(0);
        }
    }
}
