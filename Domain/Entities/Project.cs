using Domain.Common;
using Domain.Entities.Identity;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities 
{ 
    public class Project :BaseEntity
    
    {
        public string Name { get; private set; }

        public string Description { get; private set; }

        public string Link { get; private set; }

        public DateTime Date { get; private set; }

        public string UserId { get; private set; }

        public virtual User User { get; private set; }

    }
}

