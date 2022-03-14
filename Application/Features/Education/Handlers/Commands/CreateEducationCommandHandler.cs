using Application.DTOs.Education;
using Application.DTOs.Education.Validator;
using Application.Features.Education.Request.Commands;
using Application.Persistence;
using Application.Responses;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Education.Handlers.Commands
{
    public class CreateEducationCommandHandler : IRequestHandler<CreateEducationCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public CreateEducationCommandHandler( IUnitOfWork unitOfWork , IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
      
        public async Task<BaseCommandResponse> Handle(CreateEducationCommand request, CancellationToken cancellationToken)
        {

            var response = new BaseCommandResponse();

            var validator = new EducationDtoValidator();

            var validationResult = await validator.ValidateAsync(request.Educationdto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var education = _mapper.Map<Domain.Entities.Education>(request.Educationdto);
                education = await _unitOfWork.educationRepository.Add(education);
                await _unitOfWork.Save();
                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = education.Id;
            }
            return response;
        }
    }
}
