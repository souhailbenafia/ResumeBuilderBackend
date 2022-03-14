using Application.DTOs.Skill;
using Application.DTOs.SocialNetwork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SocialNetwork.Request.Commands
{
    public class UpdateSocialNetworkCommand : IRequest<Unit>
    {
        public SocialNetworkDto SocialNetworkDto { get; set; }
    }
}
