using Application.DTOs.Experience;
using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Experience.Request.Commands
{
    public class CreateExperianceCommand : IRequest<BaseCommandResponse> 
    {
        public ExperienceDto experianceDto { get; set; }
    }
}
