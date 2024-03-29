﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Education.Validator
{
    public class EducationDtoValidator : AbstractValidator<EducationDto>
    {
        public EducationDtoValidator()
        {
           
            RuleFor(p => p.University)
               .NotEmpty().WithMessage("{PropertyName} is required.").NotNull();
            RuleFor(p => p.Diploma)
               .NotEmpty().WithMessage("{PropertyName} is required.").NotNull();
            RuleFor(p => p.Start)
               .NotEmpty().WithMessage("{PropertyName} is required.").NotNull();
            RuleFor(p => p.End)
               .NotEmpty().WithMessage("{PropertyName} is required.").NotNull();

        }

    }
}
