using Application.DTOs.Experience.Validator;
using Application.Exceptions;
using Application.Features.Experience.Request.Commands;
using Application.Persistence;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Experience.Handlers.Commands
{
    public class UpdateExperianceCommandHandler : IRequestHandler<UpdateExperianceCommand, Unit>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UpdateExperianceCommandHandler(IUnitOfWork unitOfWork , IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }
        public async Task<Unit> Handle(UpdateExperianceCommand request, CancellationToken cancellationToken)
        {

            var validator = new ExperienceDtoValidator();
            var validatorResult = await validator.ValidateAsync(request.experianceDto);
            if(validatorResult.IsValid == false)
                throw new ValidationException(validatorResult);
            var Experiance = await _unitOfWork.experianceRepository.Get(request.experianceDto.Id);
            if(Experiance == null)throw new NotFoundException(nameof(Experiance), request.experianceDto.Id);

            _mapper.Map(request.experianceDto, Experiance);

            await _unitOfWork.experianceRepository.Update(Experiance);
            await _unitOfWork.Save();


            return Unit.Value;

        }
    }
}
