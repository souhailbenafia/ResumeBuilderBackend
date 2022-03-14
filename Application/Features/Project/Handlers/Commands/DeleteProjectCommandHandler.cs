using AutoMapper;
using MediatR;
using Application.Features.LeaveTypes.Requests.Commands;
using Application.Persistence;
using Application.Exceptions;

namespace Application.Features.LeaveTypes.Handlers.Commands
{
    public class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteProjectCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _unitOfWork.projectRepository.Get(request.Id);

            if (project == null)
                throw new NotFoundException(nameof(project), request.Id);

            await _unitOfWork.projectRepository.Delete(project);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
