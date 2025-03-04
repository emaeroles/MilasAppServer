using Application.DTOs.Kiosco;
using FluentValidation;

namespace API.Validators.Kiosco
{
    public class UpdateKioscoValid : AbstractValidator<UpdateKioscoInput>
    {
        public UpdateKioscoValid() 
        {
            RuleFor(x => x.Id)
                .NotEmpty();
            RuleFor(x => x.Name)
                .NotEmpty()
                .Length(3, 45);
            RuleFor(x => x.Manager)
                .NotEmpty()
                .Length(3, 45);
            RuleFor(x => x.Phone)
                .NotEmpty()
                .Matches(@"^\d+$")
                .Length(10, 10)
                .WithMessage("'{PropertyName}' debe tener 10 numeros, ej: 3515445566");
            RuleFor(x => x.Address)
                .NotEmpty()
                .Length(3, 95);
        }
    }
}
