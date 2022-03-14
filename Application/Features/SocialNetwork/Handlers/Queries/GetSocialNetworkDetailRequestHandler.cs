using Application.DTOs.Skill;
using Application.DTOs.SocialNetwork;
using Application.Features.Skill.Request.Queries;
using Application.Features.SocialNetwork.Request.Queries;
using Application.Persistence;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SocialNetwork.Handlers.Queries
{
    public class GetSocialNetworkDetailRequestHandler : IRequestHandler<GetSocialNetworkDetailRequest, SocialNetworkDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetSocialNetworkDetailRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<SocialNetworkDto> Handle(GetSocialNetworkDetailRequest request, CancellationToken cancellationToken)
        {

            var socialNetwork = await _unitOfWork.socialNetworkRepository.Get(request.Id);
            return _mapper.Map<SocialNetworkDto>(socialNetwork);

        }

     
    }
}
