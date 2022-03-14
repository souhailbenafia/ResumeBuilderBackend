using Application.DTOs.Skill;
using Application.Features.Skill.Request.Queries;
using Application.Persistence;
using AutoMapper;
using MediatR;

namespace Application.Features.Skill.Handlers.Queries
{
    public class GetSocialNetworkListRequestHandler : IRequestHandler<GetSkillListRequest, List<SkillDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetSocialNetworkListRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<SkillDto>> Handle(GetSkillListRequest request, CancellationToken cancellationToken)
        {
            var skills = await _unitOfWork.skillRepository.GetAll();
            return _mapper.Map<List<SkillDto>>(skills);
        }
    }
}
