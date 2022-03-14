using AutoMapper;
using Application.Exceptions;
using Application.Features.Language.Request.Commands;
using Application.Persistence;
using MediatR;
using Domain.Entities;
namespace Application.Features.LeaveTypes.Handlers.Commands
{
    public class DeleteLanguageCommandHandler : IRequestHandler<DeleteLanguageCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteLanguageCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteLanguageCommand request, CancellationToken cancellationToken)
        {
            var language = await _unitOfWork.languageRepository.Get(request.Id);

            if (language == null)
                throw new NotFoundException(nameof(Language), request.Id);

            await _unitOfWork.languageRepository.Delete(language);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
