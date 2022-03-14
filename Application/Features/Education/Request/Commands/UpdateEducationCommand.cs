using Application.DTOs.Education;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Education.Request.Commands
{
    public class UpdateEducationCommand : IRequest<Unit>
    {
        public EducationDto EducationDto { get; set; }
    }
}
