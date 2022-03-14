using Application.Features.Language.Request.Commands;
using Application.Persistence;
using MediatR;
using AutoMapper;
using Application.DTOs.Language.Validator;
using Application.Exceptions;

namespace Application.Features.LeaveTypes.Handlers.Commands
{
    public class UpdateLanguageCommandHandler : IRequestHandler<UpdateLanguageCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateLanguageCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateLanguageCommand request, CancellationToken cancellationToken)
        {
            var validator = new LanguageDtoValidator();
            var validationResult = await validator.ValidateAsync(request.languageDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var leaveType = await _unitOfWork.languageRepository.Get(request.languageDto.Id);

            if (leaveType is null)
                throw new NotFoundException(nameof(leaveType),request.languageDto.Id);

            _mapper.Map(request.languageDto, leaveType);

            await _unitOfWork.languageRepository.Update(leaveType);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
