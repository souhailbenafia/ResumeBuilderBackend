using Application.DTOs.User;
using MediatR;
using Application.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.User.Request.Queries
{
    public class GetAllRequest : IRequest<PagedList<UserDto>>
    {
        public UserParameters  UserParameters { get; set; }
    }

    public class UserParameters
    {
        const int maxPageSize = 50;
        public int PageNumber { get; set; } = 1;
        private int _pageSize = 10;
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }
    }
}
