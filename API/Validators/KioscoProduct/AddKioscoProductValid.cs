using Application.DTOs.KioscoProduct;
using FluentValidation;

namespace API.Validators.KioscoProduct
{
    public class AddKioscoProductValid : AbstractValidator<AddKioscoProductInput>
    {
        public AddKioscoProductValid()
        {
            RuleFor(x => x.ProductId)
                .NotEmpty();
            RuleFor(x => x.KioscoId)
                .NotEmpty();
        }
    }
}
