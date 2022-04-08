using Application.DTOs.Info;
using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Info.Request.Commands
{
    public class CreateInfoCommand : IRequest<BaseCommandResponse>
    {
        public InfoDto infoDto { get; set; }



    }
}
