using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Project.Validator
{
    public class ProjectDtoValidator :AbstractValidator<ProjectDto>
    {
        public ProjectDtoValidator()
        {
            RuleFor(p => p.Name)
             .NotEmpty().WithMessage("{PropertyName} is required.").NotNull();
            RuleFor(p => p.Description)
             .NotEmpty().WithMessage("{PropertyName} is required.").NotNull();
            RuleFor(p => p.link)
             .NotEmpty().WithMessage("{PropertyName} is required.").NotNull();
           
        }
    }
}
