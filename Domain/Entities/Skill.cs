using Domain.Common;
using Domain.Entities.Identity;

namespace Domain.Entities
{
    public class Skill:BaseEntity
    
    {
        public string Name { get; private set; }

        public string Level  { get; private set; }


        public string UserId { get; private set; }

        public virtual User User { get; private set; }
    }
}
