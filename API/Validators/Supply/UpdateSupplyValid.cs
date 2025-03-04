﻿using Application.DTOs.Supply;
using FluentValidation;

namespace API.Validators.Supply
{
    public class UpdateSupplyValid : AbstractValidator<UpdateSupplyInput>
    {
        public UpdateSupplyValid()
        {
            RuleFor(x => x.Id)
                .NotEmpty();
            RuleFor(x => x.Name)
                .NotEmpty()
                .Length(3, 45);
            RuleFor(x => x.Quantity)
                .GreaterThan(0);
            RuleFor(x => x.UoMId)
                .GreaterThan(0);
            RuleFor(x => x.CostPrice)
                .GreaterThanOrEqualTo(0);
            RuleFor(x => x.Yeild)
                .GreaterThan(0);
        }
    }


}
