using Application.DTOs.Education;
using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Education.Request.Commands
{
    public class CreateEducationCommand : IRequest<BaseCommandResponse>
    {
        public EducationDto Educationdto { get; set; }
    }
}
