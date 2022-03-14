using Application.DTOs.Education.Validator;
using Application.Exceptions;
using Application.Features.Education.Request.Commands;
using Application.Persistence;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Education.Handlers.Commands
{
    public class UpdateEducationCommandHandler : IRequestHandler<UpdateEducationCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateEducationCommandHandler(IUnitOfWork unitOfWork , IMapper mapper )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }
        public async Task<Unit> Handle(UpdateEducationCommand request, CancellationToken cancellationToken)
        {

            var validator = new EducationDtoValidator();
            var validationResult = await validator.ValidateAsync(request.EducationDto);
            if (validationResult.IsValid == false)
                throw new Exceptions.ValidationException(validationResult);

            var education = await _unitOfWork.educationRepository.Get(request.EducationDto.Id);

            if (education == null)
                throw new NotFoundException(nameof(education), request.EducationDto.Id);

            _mapper.Map(request.EducationDto, education);

            await _unitOfWork.educationRepository.Update(education);
            await _unitOfWork.Save();
            return Unit.Value;

        }
    }
}
