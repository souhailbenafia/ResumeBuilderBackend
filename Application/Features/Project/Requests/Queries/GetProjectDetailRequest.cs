using Application.DTOs.Project;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.LeaveTypes.Requests.Queries
{
    public class GetProjectDetailRequest : IRequest<ProjectDto>
    {
        public int Id { get; set; }
    }
}
