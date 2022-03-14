using Application.DTOs.Project;
using Application.Features.LeaveTypes.Requests.Queries;
using Application.Persistence;
using AutoMapper;

using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.LeaveTypes.Handlers.Queries
{
    public class GetProjectListRequestHandler : IRequestHandler<GetProjectListRequest, List<ProjectDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetProjectListRequestHandler( IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<ProjectDto>> Handle(GetProjectListRequest request, CancellationToken cancellationToken)
        {
            var Projects = await _unitOfWork.projectRepository.GetAll();
            return _mapper.Map<List<ProjectDto>>(Projects);
        }
    }
}
