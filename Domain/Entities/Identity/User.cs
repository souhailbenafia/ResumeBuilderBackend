using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Identity
{
    public class User : IdentityUser<string>
    {
        public string FirstName { get; set; }

        public string LastName { get;  set; }

        public string Genre { get;  set; }

        public DateTime BirthDate { get;   set; }

        public String   Position { get;  set; }

        public virtual IList<Certification> Certifications{ get; private set; }

        public virtual IList<Education> Educations{ get; private set; }

        public virtual IList<Experience> Experiences{ get; private set; }

        public virtual IList<Interest> Interests{ get; private set; }

        public virtual IList<Skill> Skills{ get; private set; }

        public virtual IList<Language> Languages{ get; private set; }

        public virtual IList<Project> Projects{ get; private set; }

        public virtual IList<SocialNetwork> SocialNetworks{ get; private set; }

        public virtual Info Info{ get; private set; }

    }
   
}
