using AutoMapper;
using Application.DTOs.Language.Validator;
using Application.Exceptions;
using Application.Features.Language.Request.Commands;
using Application.Persistence;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Responses;
using System.Linq;
using Domain.Entities;

namespace Application.Features.LeaveTypes.Handlers.Commands
{
    public class CreateLanguageCommandHandler : IRequestHandler< CreateLanguageCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateLanguageCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateLanguageCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new LanguageDtoValidator();
            var validationResult = await validator.ValidateAsync(request.language);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var language = _mapper.Map<Domain.Entities.Language>(request.language);

                language = await _unitOfWork.languageRepository.Add(language);
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = language.Id;
            }

            return response;
        }
    }
}
