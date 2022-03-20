using Application.DTOs.Skill;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Skill.Request.Queries
{
    public class GetSkillListRequest : IRequest<List<SkillDto>>
    {
        public string Id { get; set; }
    }
}
