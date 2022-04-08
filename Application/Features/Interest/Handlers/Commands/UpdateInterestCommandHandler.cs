using Application.DTOs.Interest.Validator;
using Application.Exceptions;
using Application.Features.Interest.Request.Commands;
using Application.Persistence;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Interest.Handlers.Commands
{
    public class UpdateInterestCommandHandler : IRequestHandler<UpdateInterestCommand, Unit>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UpdateInterestCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }

        public async Task<Unit> Handle(UpdateInterestCommand request, CancellationToken cancellationToken)
        {
            var validator = new InterestDtoValidator();
            var validatorResult = await validator.ValidateAsync(request.interestDto);
            if (validatorResult.IsValid == false)
                throw new ValidationException(validatorResult);
            var interest = await _unitOfWork.interestRepository.Get(request.interestDto.Id);
            if (interest == null) throw new NotFoundException(nameof(interest), request.interestDto.Id);

            _mapper.Map(request.interestDto, interest);

            await _unitOfWork.interestRepository.Update(interest);
            await _unitOfWork.Save();


            return Unit.Value;

        }
    }
}
