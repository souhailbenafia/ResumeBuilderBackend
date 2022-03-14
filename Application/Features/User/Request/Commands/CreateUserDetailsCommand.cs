using Application.DTOs.User;
using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.User.Request.Commands
{
    public class CreateUserDetailsCommand : IRequest<BaseCommandResponse>
    {
        public CreateUserDetailDto createUserDetailDto { get; set; }
        
    }
}
