using Application.DTOs.Common;
using Application.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.SocialNetwork
{
    public class SocialNetworkDto : BaseDto
    {
        public string Link { get;  set; }

        public string UserId { get;  set; }

        public string Network { get;  set; }

        public string Username { get;  set; }

    }
}
