using Application.DTOs.Skill.Validator;
using Application.Exceptions;
using Application.Features.Skill.Request.Commands;
using Application.Persistence;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Skill.Handlers.Commands
{
    internal class UpdateSkilllCommandHandler : IRequestHandler<UpdateSKillCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateSkilllCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

     
public async Task<Unit> Handle(UpdateSKillCommand request, CancellationToken cancellationToken)
        {
            var validator = new SkillDtoValidator();
            var validationResult = await validator.ValidateAsync(request.skillDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var skill = await _unitOfWork.skillRepository.Get(request.skillDto.Id);

            if (skill is null)
                throw new NotFoundException(nameof(skill), request.skillDto.Id);

            _mapper.Map(request.skillDto, skill);

            await _unitOfWork.skillRepository.Update(skill);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
