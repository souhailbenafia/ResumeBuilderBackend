using Application.DTOs.Skill.Validator;
using Application.Features.Skill.Request.Commands;
using Application.Persistence;
using Application.Responses;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Skill.Handlers.Commands
{
    public class CreateSocialNetworklCommandHandler : IRequestHandler<CreateSkillCommand, BaseCommandResponse>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateSocialNetworklCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateSkillCommand request, CancellationToken cancellationToken)
        {

            var response = new BaseCommandResponse();
            var validator = new SkillDtoValidator();
            var validationResult = await validator.ValidateAsync(request.skillDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var skill = _mapper.Map<Domain.Entities.Skill>(request.skillDto);

                skill = await _unitOfWork.skillRepository.Add(skill);
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = skill.Id;
            }

            return response;
        }
    }
}
