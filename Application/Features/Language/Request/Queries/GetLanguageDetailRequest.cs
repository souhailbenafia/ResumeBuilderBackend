using Application.DTOs.Language;

using MediatR;

namespace Application.Features.Language.Request.Queries
{
    public class GetLanguageDetailRequest :IRequest<LanguageDto>
    {
        public int Id { get; set; }
    }
}
