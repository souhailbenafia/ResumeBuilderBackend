using Application.DTOs.Info;
using Application.DTOs.Skill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.User
{
    public class DevDto
    {

        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public string Email { get; set; }

        public String Position { get; set; }

        public String PhoneNumber { get; set; }

        public  virtual InfoDto Info { get; set; }

        public virtual IList<SkillDto> Skills { get; set; }




    }
}
