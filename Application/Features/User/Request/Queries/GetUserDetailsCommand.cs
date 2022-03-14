﻿using Application.DTOs.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.User.Request.Queries
{
    public class GetUserDetailsCommand :IRequest<UserDto>
    {
        public string Id { get; set; }
    }
}
