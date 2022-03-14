using Application.DTOs.Certification.Validators;
using Application.Exceptions;
using Application.Features.Certification.Request.Commands;
using Application.Persistence;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Certification.Handlers.Commands
{
    public class UpdateCertificationCommandeHandler : IRequestHandler<UpdateCertificationCommande, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UpdateCertificationCommandeHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }
        public async Task<Unit> Handle(UpdateCertificationCommande request, CancellationToken cancellationToken)
        {
            var Validator = new CertificationDtoValidator();
            var validationResult = await Validator.ValidateAsync(request.certificationDto);
            if (validationResult.IsValid == false)
            {
                throw new Exceptions.ValidationException(validationResult);
            }
            var certification = await _unitOfWork.certificationRepository.Get(request.certificationDto.Id);

            if (certification == null) throw new NotFoundException(nameof(certification), request.certificationDto.Id);

            _mapper.Map(request.certificationDto, certification);

            await _unitOfWork.certificationRepository.Update(certification);
            await _unitOfWork.Save();
            return Unit.Value;
        }
    }
}
