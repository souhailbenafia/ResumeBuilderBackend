using FluentValidation;
using HR.LeaveManagement.Application.DTOs.Interest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Interest.Validator
{
    public class InterestDtoValidator : AbstractValidator<InterestDto>
    {
        public InterestDtoValidator()
        {
            RuleFor(p => p.Name)
             .NotEmpty().WithMessage("{PropertyName} is required.").NotNull();
        }
    }
}
