using Application.DTOs.ProductKiosco;
using FluentValidation;

namespace API.Validators.ProductKiosco
{
    public class UpdateProductKioscoPriceValid : AbstractValidator<UpdateProductKioscoPriceIuput>
    {
        public UpdateProductKioscoPriceValid()
        {
            RuleFor(x => x.ProductId)
                .NotEmpty();
            RuleFor(x => x.KioscoId)
                .NotEmpty();
            RuleFor(x => x.KioscoSalePrice)
                .GreaterThanOrEqualTo(0);
        }
    }
}
