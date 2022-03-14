using Application.DTOs.Experience;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Experience.Request.Queries
{
    public class GetExperianceListRequest : IRequest<List<ExperienceDto>>
    {

    }
}
