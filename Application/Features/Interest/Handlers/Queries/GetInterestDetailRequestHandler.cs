using Application.Features.Interest.Request.Queries;
using Application.Persistence;
using AutoMapper;
using HR.LeaveManagement.Application.DTOs.Interest;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Interest.Handlers.Queries
{
    public  class GetInterestDetailRequestHandler : IRequestHandler<GetInterestDetailRequest, InterestDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetInterestDetailRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async  Task<InterestDto> Handle(GetInterestDetailRequest request, CancellationToken cancellationToken)
        {
            var interset = await _unitOfWork.interestRepository.Get(request.Id);
            return _mapper.Map<InterestDto>(interset);
        }
    }
}
