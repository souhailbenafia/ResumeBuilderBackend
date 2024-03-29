﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.User.Validator
{
    public class CreateUserValidator : AbstractValidator<CreateUserDto>
    {
        public CreateUserValidator()
        {
            RuleFor(p => p.BirthDate)
             .NotEmpty().WithMessage("{PropertyName} is required.")
             .NotNull();
            RuleFor(p => p.FirstName)
             .NotEmpty().WithMessage("{PropertyName} is required.")
             .NotNull();
            RuleFor(p => p.LastName)
             .NotEmpty().WithMessage("{PropertyName} is required.")
             .NotNull();
            RuleFor(p => p.Genre)
             .NotEmpty().WithMessage("{PropertyName} is required.")
             .NotNull();
            RuleFor(p => p.Email)
             .NotEmpty().WithMessage("{PropertyName} is required.")
             .NotNull();
            RuleFor(p => p.Password)
             .NotEmpty().WithMessage("{PropertyName} is required.");
            
        }
}
}
