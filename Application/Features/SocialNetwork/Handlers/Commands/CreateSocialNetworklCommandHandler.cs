using Application.DTOs.Skill.Validator;
using Application.DTOs.SocialNetwork.Validator;
using Application.Features.Skill.Request.Commands;
using Application.Features.SocialNetwork.Request.Commands;
using Application.Persistence;
using Application.Responses;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SocialNetwork.Handlers.Commands
{
    public class CreateSocialNetworklCommandHandler : IRequestHandler<CreateSocialNetworkCommand, BaseCommandResponse>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateSocialNetworklCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateSocialNetworkCommand request, CancellationToken cancellationToken)
        {

            var response = new BaseCommandResponse();
            var validator = new SocialNetworkDtoValidator();
            var validationResult = await validator.ValidateAsync(request.SocialNetworkDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var socialNetwork = _mapper.Map<Domain.Entities.SocialNetwork>(request.SocialNetworkDto);

                socialNetwork = await _unitOfWork.socialNetworkRepository.Add(socialNetwork);
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = socialNetwork.Id;
            }

            return response;
        }
    }
}
