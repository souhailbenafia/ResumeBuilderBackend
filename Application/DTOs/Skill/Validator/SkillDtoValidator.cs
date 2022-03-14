using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Skill.Validator
{
    public class SkillDtoValidator : AbstractValidator<SkillDto>
    {
        public SkillDtoValidator()
        {

            RuleFor(p => p.Level)
             .NotEmpty().WithMessage("{PropertyName} is required.").NotNull();

            RuleFor(p => p.Name)
             .NotEmpty().WithMessage("{PropertyName} is required.").NotNull();

            RuleFor(p => p.Keywords)
             .NotEmpty().WithMessage("{PropertyName} is required.").NotNull();

        }
    }
}
