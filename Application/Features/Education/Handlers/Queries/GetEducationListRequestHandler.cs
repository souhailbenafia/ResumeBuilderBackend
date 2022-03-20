using Application.DTOs.Education;
using Application.Features.Education.Request.Queries;
using Application.Persistence;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Education.Handlers.Queries
{
    public class GetEducationListRequestHandler : IRequestHandler<GetEducationListRequest, List<EducationDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetEducationListRequestHandler(IUnitOfWork unitOfWork , IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task<List<EducationDto>> Handle(GetEducationListRequest request, CancellationToken cancellationToken)
        
        {
            var educations = await _unitOfWork.educationRepository.GetAllEducationByUser(request.Id);   
           return _mapper.Map<List<EducationDto>>(educations);  
        }
    }
}
