using Application.DTOs.Language;
using MediatR;


namespace Application.Features.Language.Request.Commands
{
    public class UpdateLanguageCommand :IRequest<Unit>
    {
        public LanguageDto languageDto { get; set; }

    }
}
