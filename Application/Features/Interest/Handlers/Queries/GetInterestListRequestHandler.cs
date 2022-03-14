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
    public class GetInterestListRequestHandler : IRequestHandler<GetInterestListRequest, List<InterestDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetInterestListRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<InterestDto>> Handle(GetInterestListRequest request, CancellationToken cancellationToken)
        {
            var intersets = await _unitOfWork.interestRepository.GetAll();
            return _mapper.Map<List<InterestDto>>(intersets);
        }
    }
    
}

