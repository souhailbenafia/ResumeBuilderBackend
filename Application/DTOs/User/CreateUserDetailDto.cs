using Application.DTOs.Certification;
using Application.DTOs.Common;
using Application.DTOs.Education;
using Application.DTOs.Experience;
using Application.DTOs.Language;
using Application.DTOs.Project;
using Application.DTOs.Skill;
using Application.DTOs.SocialNetwork;
using HR.LeaveManagement.Application.DTOs.Interest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.User
{
    public class CreateUserDetailDto : BaseDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Genre { get; set; }
        public virtual IList<CertificationDto> Certifications { get;  set; }

        public virtual IList<EducationDto> Educations { get;  set; }

        public virtual IList<ExperienceDto> Experiences { get;  set; }

        public virtual IList<InterestDto> Interests { get;  set; }

        public virtual IList<SkillDto> Skills { get;  set; }

        public virtual IList<LanguageDto> Languages { get;  set; }

        public virtual IList<ProjectDto> Projects { get;  set; }

        public virtual IList<SocialNetworkDto> SocialNetworks { get;  set; }
    }
}
