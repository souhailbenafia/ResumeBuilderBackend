using HR.LeaveManagement.Application.DTOs.Interest;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Interest.Request.Queries
{
    public class GetInterestListRequest : IRequest<List<InterestDto>>
    {
    }
}
