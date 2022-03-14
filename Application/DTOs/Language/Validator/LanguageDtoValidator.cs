using FluentValidation;

namespace Application.DTOs.Language.Validator
{
    public class LanguageDtoValidator : AbstractValidator<LanguageDto>
    {
        public LanguageDtoValidator()
        {
            RuleFor(p => p.Languge)
             .NotEmpty().WithMessage("{PropertyName} is required.").NotNull();
            RuleFor(p => p.Fluency)
             .NotEmpty().WithMessage("{PropertyName} is required.").NotNull();
            RuleFor(p => p.Niveau)
             .NotEmpty().WithMessage("{PropertyName} is required.").NotNull();
        }
    }
}
