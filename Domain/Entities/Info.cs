using Domain.Common;
using Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Info:BaseEntity
    {
        public string info { get;  private set; }

        public string description { get; set; }

        public string address { get; private set; }

        public int yearOfExpirence { get; set; }

        public string UserId { get; private set; }

        public virtual User User { get; private set; }




     


    }
}
