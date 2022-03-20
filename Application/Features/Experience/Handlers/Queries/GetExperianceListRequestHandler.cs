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
    public class GetExperianceListRequestHandler : IRequestHandler<GetExperianceListRequest, List<ExperienceDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetExperianceListRequestHandler(IUnitOfWork unitOfWork , IMapper mapper)
        { 
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }
        public async Task<List<ExperienceDto>> Handle(GetExperianceListRequest request, CancellationToken cancellationToken)
        {
            var experiances = await _unitOfWork.experianceRepository.GetAllExperienceByUser(request.Id);
            return _mapper.Map<List<ExperienceDto>>(experiances);
        }
    }
}
