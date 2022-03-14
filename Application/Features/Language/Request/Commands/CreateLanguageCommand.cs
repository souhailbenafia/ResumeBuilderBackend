using Application.DTOs.Language;
using Application.Responses;
using MediatR;

namespace Application.Features.Language.Request.Commands
{
    public class CreateLanguageCommand : IRequest<BaseCommandResponse>
    {
        public LanguageDto language { get; set; }
    }
}
