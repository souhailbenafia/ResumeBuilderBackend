using AutoMapper;
using MediatR;
using Application.Features.LeaveTypes.Requests.Commands;
using Application.Persistence;
using Application.Exceptions;
using Application.DTOs.Project.Validator;

namespace Application.Features.LeaveTypes.Handlers.Commands
{
    public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateProjectCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            var validator = new ProjectDtoValidator();
            var validationResult = await validator.ValidateAsync(request.projectDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var project = await _unitOfWork.projectRepository.Get(request.projectDto.Id);

            if (project is null)
                throw new NotFoundException(nameof(project), request.projectDto.Id);

            _mapper.Map(request.projectDto, project);

            await _unitOfWork.projectRepository.Update(project);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
