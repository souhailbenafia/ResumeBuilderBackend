using Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Info
{
    public class InfoDto : BaseDto
    {
        public string info { get; set; }

        public string description { get; set; }

        public string address { get;  set; }
        public string imageSource { get; set; }

        public int yearOfExpirence { get; set; }

        public string UserId { get;  set; }

      
    }
}
