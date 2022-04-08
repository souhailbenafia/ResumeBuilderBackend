using Domain.Common;
using Domain.Entities.Identity;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class FileModel : BaseEntity
    {
        public string FileName { get;  private set; }

        public IFormFile FormFile { get; private set; }

        public string UserId { get; private set; }

        public virtual User User { get; private set; }


    }
}
