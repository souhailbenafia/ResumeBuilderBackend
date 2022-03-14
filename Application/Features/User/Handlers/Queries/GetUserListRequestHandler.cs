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
    public class GetUserListRequestHandler : IRequestHandler<GetUserListRequest, List<UserDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetUserListRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        async Task<List<UserDto>> IRequestHandler<GetUserListRequest, List<UserDto>>.Handle(GetUserListRequest request, CancellationToken cancellationToken)
        {
            var users = await _unitOfWork.userRepository.GetAll();
            return _mapper.Map<List<UserDto>>(users);
        }
    }
}
