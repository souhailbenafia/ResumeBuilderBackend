using MediatR;


namespace Application.Features.Language.Request.Commands
{
    public class DeleteLanguageCommand : IRequest
    {
        public int Id { get; set; }
    }
}
