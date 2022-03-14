using Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Certification
{
    public class CertificationDto : BaseDto
    {
        public DateTime AquisationDate { get; set; }

        public string Source { get; set; }

        public string Name { get; set; }

        public int UserId { get; set; }
    }
}
