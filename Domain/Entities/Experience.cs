


using Domain.Common;
using Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public  class Experience : BaseEntity

    {
        
        public string  Position { get; private set; }
        
        public DateTime Start { get; private set; }
        
        public DateTime End { get; private set; }
        
        public string Description { get; private set; }
        
        public string Company { get; private set; }
        
        public string Location { get; private set; }
        
        public string UserId { get; private set; }

        public virtual User User { get; private set; }
    }
}
