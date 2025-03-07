using Application.DTOs.User;
using FluentValidation;

namespace API.Validators.User
{
    public class UpdateUserValid : AbstractValidator<UpdateUserInput>
    {
        public UpdateUserValid() 
        {
            RuleFor(x => x.Id)
                .NotEmpty();
            RuleFor(x => x.Username)
                .NotEmpty()
                .Length(3, 10);
            RuleFor(x => x.Password)
                .NotEmpty()
                .Length(8, 16)
                .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).+$")
                .WithMessage("'{PropertyName}' must contain at least one lowercase letter, " +
                    "one uppercase letter, and one number.");
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();
        }
    }
}
