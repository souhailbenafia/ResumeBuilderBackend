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
    public class GetRequestHandler : IRequestHandler<GetRequest, List<DevDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }
        public async Task<List<DevDto>> Handle(GetRequest request, CancellationToken cancellationToken)
        {
            var users = await _unitOfWork.userRepository.GetAllUser();
            return _mapper.Map<List<DevDto>>(users);
        }
    }
}
