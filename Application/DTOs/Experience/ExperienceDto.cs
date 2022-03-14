using Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.Experience
{
    public class ExperienceDto : BaseDto
    {

        public string Position { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public string Description { get; set; }

        public string Company { get; set; }

        public string Location { get; set; }

        public int UserId { get; set; }
    }
}
