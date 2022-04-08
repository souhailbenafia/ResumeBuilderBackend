using Domain.Common;
using Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Education : BaseEntity
    {
        public string University { get; private set; }

        public DateTime Start { get; private set; }

        public DateTime End { get; private set; }

        public string Diploma { get; private set; }

        public string UserId { get; private set; }

        public virtual User User { get; private set; }
    }
}
