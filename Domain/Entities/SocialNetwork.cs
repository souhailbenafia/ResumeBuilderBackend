using Domain.Common;
using Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class SocialNetwork : BaseEntity

    {

        public string Link { get; private set; }

        public string UserId { get; private set; }

        public string  Network { get; private set; }

        public string Username { get; private set; }

        public virtual User User { get; private set; }
    }
}
