
using Application.DTOs.SocialNetwork;
using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SocialNetwork.Request.Commands
{
    public class CreateSocialNetworkCommand  : IRequest<BaseCommandResponse>
    {
        public SocialNetworkDto SocialNetworkDto { get; set; }
    }
}
