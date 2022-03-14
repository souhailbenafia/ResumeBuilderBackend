using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Identity
{
    public class User : IdentityUser<string>
    {
        public DateTime BirthDate { get;  private set; }

        public String   BirthPlace { get; private  set; }

        public String   Position { get; private set; }

        public virtual IList<Certification> Certifications{ get; private set; }

        public virtual IList<Education> Educations{ get; private set; }

        public virtual IList<Experience> Experiences{ get; private set; }

        public virtual IList<Interest> Interests{ get; private set; }

        public virtual IList<Skill> Skills{ get; private set; }

        public virtual IList<Language> Languages{ get; private set; }

        public virtual IList<Project> Projects{ get; private set; }

        public virtual IList<SocialNetwork> SocialNetworks{ get; private set; }

    }
   
}
