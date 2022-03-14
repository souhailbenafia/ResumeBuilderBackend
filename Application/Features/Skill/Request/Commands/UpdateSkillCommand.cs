using Application.DTOs.Skill;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Skill.Request.Commands
{
    public class UpdateSKillCommand : IRequest<Unit>
    {
        public SkillDto  skillDto { get; set; }
    }
}
