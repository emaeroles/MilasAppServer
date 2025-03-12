using Application.DTOs.KioscoProduct;
using FluentValidation;

namespace API.Validators.KioscoProduct
{
    public class UpdateKioscoProductPriceValid : AbstractValidator<UpdateKioscoProductPriceIuput>
    {
        public UpdateKioscoProductPriceValid()
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
