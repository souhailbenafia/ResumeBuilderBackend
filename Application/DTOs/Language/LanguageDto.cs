using Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.Language
{
    public class LanguageDto : BaseDto
    { 
        public string Languge { get; set; }

        public string Niveau { get; set; }

        public string Fluency { get; set; }

        public string UserId { get; set; }

    }
}
