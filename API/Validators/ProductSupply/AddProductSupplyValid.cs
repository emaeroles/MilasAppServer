using Application.DTOs.ProductSupply;
using FluentValidation;

namespace API.Validators.ProductSupply
{
    public class AddProductSupplyValid : AbstractValidator<AddProductSupplyInput>
    {
        public AddProductSupplyValid() 
        {
            RuleFor(x => x.SupplyId)
                .NotEmpty();
            RuleFor(x => x.ProductId)
                .NotEmpty();
        }
    }
}
