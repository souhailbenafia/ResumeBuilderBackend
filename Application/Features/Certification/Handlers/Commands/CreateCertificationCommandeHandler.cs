using Application.DTOs.Certification.Validators;
using Application.Features.Certification.Request.Commands;
using Application.Persistence;
using Application.Responses;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Application.Features.Certification.Handlers.Commands
{
    public class CreateCertificationCommandeHandler : IRequestHandler<CreateCertificationCommande, BaseCommandResponse>
    {

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateCertificationCommandeHandler(IUnitOfWork unitOfWork , IMapper mapper)
        {
                _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<BaseCommandResponse> Handle(CreateCertificationCommande request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateCertificationValidator();
            var validationResult = await validator.ValidateAsync(request.createCertificationDto);
            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var certification = _mapper.Map<Domain.Entities.Certification>(request.createCertificationDto);

                certification = await _unitOfWork.certificationRepository.Add(certification);
                await _unitOfWork.Save();
                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = certification.Id;
            }
            return response;

        }
    }
}
