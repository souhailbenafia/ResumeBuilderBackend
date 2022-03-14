using Application.DTOs.Project;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.LeaveTypes.Requests.Commands
{
    public class UpdateProjectCommand : IRequest<Unit>
    {
        public ProjectDto projectDto { get; set; }

    }
}
