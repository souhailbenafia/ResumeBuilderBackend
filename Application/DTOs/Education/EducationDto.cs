using Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.Education
{
    public class EducationDto :BaseDto
    {

        public string University { get; set; }

        public string Localisation { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public string Description { get; set; }

        public string Diploma { get; set; }

        public int UserId { get; set; }

      
    }
}
