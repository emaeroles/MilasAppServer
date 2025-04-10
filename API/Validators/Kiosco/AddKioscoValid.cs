﻿using Application.DTOs.Kiosco;
using FluentValidation;

namespace API.Validators.Kiosco
{
    public class AddKioscoValid : AbstractValidator<AddKioscoInput>
    {
        public AddKioscoValid() 
        {
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
                .WithMessage("'{PropertyName}' contain exactly 10 digits, like: 3515445566.");
            RuleFor(x => x.Address)
                .NotEmpty()
                .Length(3, 95);
            RuleFor(x => x.UserId)
                .NotEmpty();
        }
    }
}
