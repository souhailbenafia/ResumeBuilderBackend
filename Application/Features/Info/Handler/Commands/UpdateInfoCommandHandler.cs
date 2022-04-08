using Application.DTOs.Info.Validator;
using Application.Exceptions;
using Application.Features.Info.Request.Commands;
using Application.Features.Interest.Request.Commands;
using Application.Persistence;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Info.Handler.Commands
{
    public class UpdateInfoCommandHandler : IRequestHandler<UpdateInfoCommand, Unit>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UpdateInfoCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }
        public async Task<Unit> Handle(UpdateInfoCommand request, CancellationToken cancellationToken)
        {
            var validator = new InfoDtoValidator();
            var validatorResult = await validator.ValidateAsync(request.infoDto);
            if (validatorResult.IsValid == false)
                throw new ValidationException(validatorResult);
            var info = await _unitOfWork.infoRepository.Get(request.infoDto.Id);
            if (info == null) throw new NotFoundException(nameof(info), request.infoDto.Id);

            _mapper.Map(request.infoDto, info);

            await _unitOfWork.infoRepository.Update(info);
            await _unitOfWork.Save();


            return Unit.Value;
        }
    }
}
