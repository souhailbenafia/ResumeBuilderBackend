﻿using Application.DTOs.Common;
using Microsoft.OData.Edm;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.Project
{
    public class ProjectDto : BaseDto
    {
      
        public string Name { get; set; }

        public string Description { get; set; }

        public string link { get; set; }

        public Date Date { get; set; }

        public int UserId { get; set; }

    }
}