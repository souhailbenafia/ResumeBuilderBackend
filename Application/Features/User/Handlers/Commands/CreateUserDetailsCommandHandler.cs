using Application.DTOs.User;
using Application.DTOs.User.Validator;
using Application.Features.User.Request.Commands;
using Application.Persistence;
using Application.Responses;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.User.Handlers.Commands
{
    public class CreateUserDetailsCommandHandler : IRequestHandler<CreateUserDetailsCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateUserDetailsCommandHandler( IUnitOfWork unitOfWork , IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(CreateUserDetailsCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateUserDetailsValidator();
            var validationResult = await validator.ValidateAsync(request.createUserDetailDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var userDetails = _mapper.Map<Domain.Entities.Identity.User>(request.createUserDetailDto);

                userDetails = await _unitOfWork.userRepository.Add(userDetails);
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Creation Successful";
            }
            return response;

        }
    }
}
