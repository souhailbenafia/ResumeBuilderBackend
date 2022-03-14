using HR.LeaveManagement.Application.DTOs.Interest;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Interest.Request.Commands
{
    public class UpdateInterestCommand : IRequest<Unit>
    {
        public InterestDto interestDto { get; set; }
    }
}
