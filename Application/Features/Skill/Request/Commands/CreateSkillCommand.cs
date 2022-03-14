using Application.DTOs.Skill;
using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Skill.Request.Commands
{
    public class CreateSkillCommand  : IRequest<BaseCommandResponse>
    {
        public SkillDto skillDto { get; set; }
    }
}
