using Application.DTOs.Education;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Education.Request.Queries
{
    public class GetEducationListRequest : IRequest<List<EducationDto>>
    {
        public string Id { get; set; }
    }
}
