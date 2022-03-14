using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Experience.Validator
{
    public class ExperienceDtoValidator : AbstractValidator<ExperienceDto>
    {
        public ExperienceDtoValidator()
        {
            RuleFor(p => p.Location)
              .NotEmpty().WithMessage("{PropertyName} is required.").NotNull();

            RuleFor(p => p.Description)
              .NotEmpty().WithMessage("{PropertyName} is required.").NotNull();

            RuleFor(p => p.Company)
              .NotEmpty().WithMessage("{PropertyName} is required.").NotNull();
           
            RuleFor(p => p.Position)
              .NotEmpty().WithMessage("{PropertyName} is required.").NotNull();

            RuleFor(p => p.Start)
              .NotEmpty().WithMessage("{PropertyName} is required.").NotNull();

            RuleFor(p => p.End)
             .NotEmpty().WithMessage("{PropertyName} is required.").NotNull();

           
        }

    }
}
