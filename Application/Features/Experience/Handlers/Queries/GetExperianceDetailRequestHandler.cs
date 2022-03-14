using Application.DTOs.Experience;
using Application.Features.Experience.Request.Queries;
using Application.Persistence;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Experience.Handlers.Queries
{
    public class GetExperianceDetailRequestHandler : IRequestHandler<GetExperianceDetailRequest, ExperienceDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetExperianceDetailRequestHandler(IUnitOfWork unitOfWork , IMapper mapper)
        {
            _unitOfWork = unitOfWork;   
            _mapper = mapper;
        }
        public async Task<ExperienceDto> Handle(GetExperianceDetailRequest request, CancellationToken cancellationToken)
        {
            var Experiance = await _unitOfWork.experianceRepository.Get(request.Id);
            return _mapper.Map<ExperienceDto>(Experiance);
        }
    }
}
