using Application.Responses;
using HR.LeaveManagement.Application.DTOs.Interest;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Interest.Request.Commands
{
    public class CreateInterestCommand : IRequest<BaseCommandResponse>
    {
        public InterestDto interestDto { get; set; }
    }
}
