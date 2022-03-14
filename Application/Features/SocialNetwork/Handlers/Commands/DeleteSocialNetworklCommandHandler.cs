using Application.Exceptions;
using Application.Features.Skill.Request.Commands;
using Application.Features.SocialNetwork.Request.Commands;
using Application.Persistence;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SocialNetwork.Handlers.Commands
{
    public class DeleteSocialNetworklCommandHandler : IRequestHandler<DeleteSocialNetworkCommand>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteSocialNetworklCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

     
        public async Task<Unit> Handle(DeleteSocialNetworkCommand request, CancellationToken cancellationToken)
        {
            var socialNetwork = await _unitOfWork.socialNetworkRepository.Get(request.Id);

            if (socialNetwork == null)
                throw new NotFoundException(nameof(socialNetwork), request.Id);

            await _unitOfWork.socialNetworkRepository.Delete(socialNetwork);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
