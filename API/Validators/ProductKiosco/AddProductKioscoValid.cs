using Application.DTOs.ProductKiosco;
using FluentValidation;

namespace API.Validators.ProductKiosco
{
    public class AddProductKioscoValid : AbstractValidator<AddProductKioscoInput>
    {
        public AddProductKioscoValid()
        {
            RuleFor(x => x.ProductId)
                .NotEmpty();
            RuleFor(x => x.KioscoId)
                .NotEmpty();
        }
    }
}
