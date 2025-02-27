using Application.DTOs.Product;
using FluentValidation;

namespace API.Validators.Product
{
    public class AddProductValid : AbstractValidator<AddProductInput>
    {
        public AddProductValid()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .Length(3, 45);
            RuleFor(x => x.CostPrice)
                .GreaterThanOrEqualTo(0);
            RuleFor(x => x.SalePrice)
                .GreaterThanOrEqualTo(0);
        }
    }
}
