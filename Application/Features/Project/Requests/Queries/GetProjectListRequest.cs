
using Application.DTOs.Project;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.LeaveTypes.Requests.Queries
{
    public class GetProjectListRequest : IRequest<List<ProjectDto>>
    {
        public string Id { get; set; }
    }
}
