using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.SocialNetwork.Validator
{
    public class SocialNetworkDtoValidator : AbstractValidator<SocialNetworkDto>
    {
        public SocialNetworkDtoValidator()
        {
           /* RuleFor(p => p.Network)
             .NotEmpty().WithMessage("{PropertyName} is required.").NotNull();

            RuleFor(p => p.Username)
             .NotEmpty().WithMessage("{PropertyName} is required.").NotNull();

            RuleFor(p => p.Link)
             .NotEmpty().WithMessage("{PropertyName} is required.").NotNull();*/
        }
    }
}
