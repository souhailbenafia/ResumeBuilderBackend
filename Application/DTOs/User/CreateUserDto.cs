﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.User
{
    public class CreateUserDto
    {
        public DateTime BirthDate { get;  set; }
        public string FirstName { get;  set; }
        public string LastName { get; set; }
        public string Genre { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsEmailConfirmed { get; set; } = false;
        public bool IsPasswordConfirmed { get; set; } = false;
        public string Position { get; set; } = "";

    }
}
