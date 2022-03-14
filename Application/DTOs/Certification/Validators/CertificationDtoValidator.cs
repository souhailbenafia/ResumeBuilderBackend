using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Certification.Validators
{
    public class CertificationDtoValidator : AbstractValidator<CertificationDto>
    {
        public CertificationDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("{PropertyName} is required.").NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
            RuleFor(p => p.AquisationDate)
               .NotEmpty().WithMessage("{PropertyName} is required.");

            RuleFor(p =>p.Source).NotEmpty().WithMessage("{PropertyName} is required.").NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");


        }
    }
}
