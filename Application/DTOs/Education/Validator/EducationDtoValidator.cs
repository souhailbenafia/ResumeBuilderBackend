using FluentValidation;
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
            RuleFor(x => x.Description).NotEmpty().WithMessage("{PropertyName} is required.").NotNull()
               .MaximumLength(100).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
            RuleFor(p => p.University)
               .NotEmpty().WithMessage("{PropertyName} is required.").NotNull();
            RuleFor(p => p.Localisation)
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
