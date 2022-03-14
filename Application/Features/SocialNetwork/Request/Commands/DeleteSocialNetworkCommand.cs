using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SocialNetwork.Request.Commands
{
    public class DeleteSocialNetworkCommand :IRequest
    {
        public int Id { get; set; }
    }
}
