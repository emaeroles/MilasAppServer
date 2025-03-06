using Application.DTOs.Supply;
using FluentValidation;

namespace API.Validators.Supply
{
    public class AddSupplyProductValid : AbstractValidator<AddSupplyProductInput>
    {
        public AddSupplyProductValid() 
        {
            RuleFor(x => x.SupplyId)
                .NotEmpty();
            RuleFor(x => x.ProductId)
                .NotEmpty();
        }
    }
}
