using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Interest.Request.Commands
{
    public class DeleteInterestCommand : IRequest
    {
        public int Id { get; set; }
    
    }
}
