using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Info.Request.Commands
{
    public class DeleteInfoCommand : IRequest
    {
        public int Id { get; set; }
    }
}
