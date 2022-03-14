
using Application.DTOs.Project;
using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.LeaveTypes.Requests.Commands
{
    public class CreateProjectCommand : IRequest<BaseCommandResponse>
    {
        public ProjectDto projectDto { get; set; }

    }
}
