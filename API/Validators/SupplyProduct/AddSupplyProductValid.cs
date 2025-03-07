using Application.DTOs.SupplyProduct;
using FluentValidation;

namespace API.Validators.SupplyProduct
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
