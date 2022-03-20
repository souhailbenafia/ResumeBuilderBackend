using Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.Skill
{
    public class SkillDto : BaseDto
    {

        public string Name { get; set; }

        public string Level { get; set; }

        public string Keywords { get; set; }

        public string UserId { get; set; }
    }
}
