using Domain.Common;
using Domain.Entities.Identity;

namespace Domain.Entities
{
    public class Language :BaseEntity
    
    {

        public string Languge{ get; private set; }

        public string Niveau { get; private set; }

        public string Fluency { get; private set; }

        public string UserId { get; private set; }

        public virtual User User { get; private set; }

    }
}
