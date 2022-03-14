using Domain.Common;
using Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Interest : BaseEntity

    {
        public string Name{ get; private set; }

        public string UserId { get; private set; }

        public virtual User User { get; private set; }

    }
}
