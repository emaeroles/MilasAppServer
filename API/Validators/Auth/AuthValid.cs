using Application.DTOs.Auth;
using FluentValidation;

namespace API.Validators.Auth
{
    public class AuthValid : AbstractValidator<AuthInput>
    {
        public AuthValid() 
        {
            RuleFor(x => x.Username)
                .NotEmpty()
                .Length(3, 10);
            RuleFor(x => x.Password)
                .NotEmpty()
                .Length(8, 16)
                .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).+$")
                .WithMessage("'{PropertyName}' should contain at least one lowercase letter, " +
                    "one uppercase letter, and one number.");
        }
    }
}
