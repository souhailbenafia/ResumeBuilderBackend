using Application.DTOs.Skill;
using Application.Features.Skill.Request.Queries;
using Application.Persistence;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Skill.Handlers.Queries
{
    public class GetSkillDetailRequestHandler : IRequestHandler<GetSkillDetailRequest, SkillDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetSkillDetailRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<SkillDto> Handle(GetSkillDetailRequest request, CancellationToken cancellationToken)
        {

            var skill = await _unitOfWork.skillRepository.Get(request.Id);
            return _mapper.Map<SkillDto>(skill);

        }
    }
}
