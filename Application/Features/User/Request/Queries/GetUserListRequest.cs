using Application.DTOs.User;
using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.User.Request.Queries
{
    public class GetUserListRequest :IRequest<List<UserDto>>
    {
    }
}
