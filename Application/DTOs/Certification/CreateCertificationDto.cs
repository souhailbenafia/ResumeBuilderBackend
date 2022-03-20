using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Certification
{
    public class CreateCertificationDto
    {
        public DateTime AquisationDate { get; set; }

        public string Source { get; set; }

        public string Name { get; set; }

        public string UserId { get; set; }
    }
}
