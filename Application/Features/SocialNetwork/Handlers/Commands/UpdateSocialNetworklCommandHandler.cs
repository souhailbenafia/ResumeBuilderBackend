using Application.DTOs.Skill.Validator;
using Application.DTOs.SocialNetwork.Validator;
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
    internal class UpdateSocialNetworklCommandHandler : IRequestHandler<UpdateSocialNetworkCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateSocialNetworklCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

     
public async Task<Unit> Handle(UpdateSocialNetworkCommand request, CancellationToken cancellationToken)
        {
            var validator = new SocialNetworkDtoValidator();
            var validationResult = await validator.ValidateAsync(request.SocialNetworkDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var socialnetwork = await _unitOfWork.socialNetworkRepository.Get(request.SocialNetworkDto.Id);

            if (socialnetwork is null)
                throw new NotFoundException(nameof(socialnetwork), request.SocialNetworkDto.Id);

            _mapper.Map(request.SocialNetworkDto, socialnetwork);

            await _unitOfWork.socialNetworkRepository.Update(socialnetwork);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
