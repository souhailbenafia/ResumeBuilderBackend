using Application.DTOs.Project;
using Application.Features.LeaveTypes.Requests.Queries;
using Application.Persistence;
using AutoMapper;

using MediatR;


namespace Application.Features.LeaveTypes.Handlers.Queries
{
    public class GetProjectDetailRequestHandler : IRequestHandler<GetProjectDetailRequest, ProjectDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetProjectDetailRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ProjectDto> Handle(GetProjectDetailRequest request, CancellationToken cancellationToken)
        {
            var project = await _unitOfWork.projectRepository.Get(request.Id);
            return _mapper.Map<ProjectDto>(project);
        }
    }
}
