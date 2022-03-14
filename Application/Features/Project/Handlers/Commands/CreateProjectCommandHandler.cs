

using Application.DTOs.Project;
using Application.DTOs.Project.Validator;
using Application.Features.LeaveTypes.Requests.Commands;
using Application.Persistence;
using Application.Responses;
using AutoMapper;
using MediatR;

namespace Application.Features.LeaveTypes.Handlers.Commands
{
    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateProjectCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new ProjectDtoValidator();
            var validationResult = await validator.ValidateAsync(request.projectDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var project = _mapper.Map<Domain.Entities.Project>(request.projectDto);

                project = await _unitOfWork.projectRepository.Add(project);
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = project.Id;
            }

            return response;
        }
    }
}
