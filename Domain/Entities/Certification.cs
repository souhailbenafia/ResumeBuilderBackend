using Domain.Common;
using Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Certification : BaseEntity
    {
        public DateTime AquisationDate { get; private set; }

        public string Source { get; private set; }

        public string Name { get; private set; }

        public string UserId { get; private set; }

        public virtual User User { get; private set; }

    }
}
