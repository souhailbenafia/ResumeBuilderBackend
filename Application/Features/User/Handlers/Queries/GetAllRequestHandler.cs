using Application.DTOs.User;
using Application.Features.User.Request.Queries;
using Application.Persistence;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.User.Handlers.Queries
{
    public  class GetAllRequestHandler : IRequestHandler<GetAllRequest, PagedList<UserDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public  async Task<PagedList<UserDto>> Handle(GetAllRequest request, CancellationToken cancellationToken)
        {
            var users = _unitOfWork.userRepository.GetUsersP(request.UserParameters);
            return  _mapper.Map<PagedList<UserDto>>(users);
        }

       
    }
    
}
