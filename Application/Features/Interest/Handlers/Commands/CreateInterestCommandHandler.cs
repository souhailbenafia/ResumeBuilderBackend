using Application.DTOs.Interest.Validator;
using Application.Features.Interest.Request.Commands;
using Application.Persistence;
using Application.Responses;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Interest.Handlers.Commands
{
    public class CreateInterestCommandHandler : IRequestHandler<CreateInterestCommand, BaseCommandResponse>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CreateInterestCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }
        public async Task<BaseCommandResponse> Handle(CreateInterestCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new InterestDtoValidator();
            var validationResult = await validator.ValidateAsync(request.interestDto);
            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var interest = _mapper.Map<Domain.Entities.Interest>(request.interestDto);

                interest = await _unitOfWork.interestRepository.Add(interest);
                await _unitOfWork.Save();
                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = interest.Id;
            }
            return response;
        }
    }
}
