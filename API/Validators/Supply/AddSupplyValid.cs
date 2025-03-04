using Application.DTOs.Supply;
using FluentValidation;

namespace API.Validators.Supply
{
    public class AddSupplyValid : AbstractValidator<AddSupplyInput>
    {
        public AddSupplyValid() 
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .Length(3, 45);
            RuleFor(x => x.Quantity)
                .GreaterThan(0);
            RuleFor(x => x.UoMId)
                .NotEmpty();
            RuleFor(x => x.CostPrice)
                .GreaterThanOrEqualTo(0);
            RuleFor(x => x.Yeild)
                .GreaterThan(0);
        }
    }
}
