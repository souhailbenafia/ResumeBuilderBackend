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
        public string Link { get; private set; }

        public int UserId { get; private set; }

        public int Network { get; private set; }

        public string Username { get; private set; }

        public virtual UserDto User { get; private set; }
    }
}
