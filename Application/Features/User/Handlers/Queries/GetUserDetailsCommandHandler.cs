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
    public class GetUserDetailsCommandHandler : IRequestHandler<GetUserDetailsCommand, UserDto>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetUserDetailsCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async  Task<UserDto> Handle(GetUserDetailsCommand request, CancellationToken cancellationToken)
        {
            var user = _unitOfWork.userRepository.GetUserDetailById(request.Id);
           return _mapper.Map<UserDto>(user);
        }
    }
}
