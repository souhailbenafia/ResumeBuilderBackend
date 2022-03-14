using Application.DTOs.Skill;
using Application.DTOs.SocialNetwork;
using Application.Features.Skill.Request.Queries;
using Application.Features.SocialNetwork.Request.Queries;
using Application.Persistence;
using AutoMapper;
using MediatR;

namespace Application.Features.SocialNetwork.Handlers.Queries
{
    public class GetSocialNetworkListRequestHandler : IRequestHandler<GetSocialNetworkListRequest, List<SocialNetworkDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetSocialNetworkListRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<SocialNetworkDto>> Handle(GetSocialNetworkListRequest request, CancellationToken cancellationToken)
        {
            var SocialNetworks = await _unitOfWork.socialNetworkRepository.GetAll();
            return _mapper.Map<List<SocialNetworkDto>>(SocialNetworks);
        }
    }
}
