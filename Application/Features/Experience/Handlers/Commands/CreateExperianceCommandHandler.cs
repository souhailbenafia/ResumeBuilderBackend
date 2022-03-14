using Application.DTOs.Experience.Validator;
using Application.Features.Experience.Request.Commands;
using Application.Persistence;
using Application.Responses;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Experience.Handlers.Commands
{
    public class CreateExperianceCommandHandler : IRequestHandler<CreateExperianceCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CreateExperianceCommandHandler(IUnitOfWork unitOfWork , IMapper mapper )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }


        public async Task<BaseCommandResponse> Handle(CreateExperianceCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new ExperienceDtoValidator();
            var validationResult = await validator.ValidateAsync(request.experianceDto);
            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();

            }
            else
            {
                var experiance = _mapper.Map<Domain.Entities.Experience>(request.experianceDto);

                experiance = await _unitOfWork.experianceRepository.Add(experiance);
                await _unitOfWork.Save();
                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = experiance.Id;
            }
            return response;

        }
    }
}
