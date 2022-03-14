using Application.DTOs.Skill;
using Application.DTOs.SocialNetwork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SocialNetwork.Request.Queries
{
    public class GetSocialNetworkListRequest : IRequest<List<SocialNetworkDto>>
    {

    }
}
