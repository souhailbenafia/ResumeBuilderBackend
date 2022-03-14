using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.LeaveTypes.Requests.Commands
{
    public class DeleteProjectCommand : IRequest
    {
        public int Id { get; set; }
    }
}
