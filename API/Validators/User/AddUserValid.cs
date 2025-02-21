using Application.DTOs.User;
using FluentValidation;

namespace API.Validators.User
{
    public class AddUserValid : AbstractValidator<AddUserInput>
    {
        public AddUserValid() 
        {
            RuleFor(x => x.Username)
                .NotEmpty()
                .Length(3, 10);
            RuleFor(x => x.Password)
                .NotEmpty()
                .Length(8, 16)
                .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).+$")
                .WithMessage("'{PropertyName}' debe tener al menos una letra minúscula, " +
                    "al menos una letra mayúscula y al menos un número.");
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress(); 
        }
    }
}
