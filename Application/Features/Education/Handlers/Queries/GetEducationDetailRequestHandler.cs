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
    public class GetEducationDetailRequestHandler : IRequestHandler<GetEducationDetailRequest, EducationDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetEducationDetailRequestHandler(IUnitOfWork unitOfWork , IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<EducationDto> Handle(GetEducationDetailRequest request, CancellationToken cancellationToken)
        {
            var education = await _unitOfWork.educationRepository.Get(request.Id);
            return _mapper.Map<EducationDto>(education);



            throw new NotImplementedException();
        }
    }
}
