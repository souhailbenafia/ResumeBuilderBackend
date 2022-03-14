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
        public virtual IList<CertificationDto> Certifications { get; private set; }

        public virtual IList<EducationDto> Educations { get; private set; }

        public virtual IList<ExperienceDto> Experiences { get; private set; }

        public virtual IList<InterestDto> Interests { get; private set; }

        public virtual IList<SkillDto> Skills { get; private set; }

        public virtual IList<LanguageDto> Languages { get; private set; }

        public virtual IList<ProjectDto> Projects { get; private set; }

        public virtual IList<SocialNetworkDto> SocialNetworks { get; private set; }
    }
}
