using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Info.Validator
{
    public class InfoDtoValidator :AbstractValidator<InfoDto>
    {
        public InfoDtoValidator()
        {
            RuleFor(p => p.info)
               .NotEmpty().WithMessage("{PropertyName} is required.").NotNull();
            RuleFor(p => p.description)
               .NotEmpty().WithMessage("{PropertyName} is required.").NotNull();
            RuleFor(p => p.address)
               .NotEmpty().WithMessage("{PropertyName} is required.").NotNull();
            RuleFor(p => p.yearOfExpirence)
              .NotEmpty().WithMessage("{PropertyName} is required.").NotNull();
            RuleFor(p => p.UserId)
               .NotEmpty().WithMessage("{PropertyName} is required.").NotNull();
        }
    }
}
