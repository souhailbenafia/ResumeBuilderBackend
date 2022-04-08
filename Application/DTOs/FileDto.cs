using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class FileDto
    {
        public string FileName { get;  set; }

        public IFormFile FormFile { get;  set; }

        public string UserId { get;  set; }

        
    }
}
