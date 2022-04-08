using Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.Education
{
    public class EducationDto :BaseDto
    {

        public string University { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public string Diploma { get; set; }

        public string UserId { get; set; }

      
    }
}
