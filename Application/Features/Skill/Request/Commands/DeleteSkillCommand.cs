using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Skill.Request.Commands
{
    public class DeleteSKillCommand :IRequest
    {
        public int Id { get; set; }
    }
}
