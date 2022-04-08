using Application.DTOs.Info.Validator;
using Application.Features.Info.Request.Commands;
using Application.Persistence;
using Application.Responses;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Info.Handler.Commands
{
    public class CreateInfoCommandHandler : IRequestHandler<CreateInfoCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CreateInfoCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }
        public async Task<BaseCommandResponse> Handle(CreateInfoCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new InfoDtoValidator();
            var validationResult = await validator.ValidateAsync(request.infoDto);
            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var info = _mapper.Map<Domain.Entities.Info>(request.infoDto);

                info = await _unitOfWork.infoRepository.Add(info);
                await _unitOfWork.Save();
                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = info.Id;
            }
            return response;
        }
    }
}
