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
    public class DeleteInterestCommandHandler : IRequestHandler<DeleteInterestCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteInterestCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }

        public async Task<Unit> Handle(DeleteInterestCommand request, CancellationToken cancellationToken)
        {
            var interest = await _unitOfWork.interestRepository.Get(request.Id);
            if (interest == null) throw new NotFoundException(nameof(interest), request.Id);

            await _unitOfWork.interestRepository.Delete(interest);
            await _unitOfWork.Save();
            return Unit.Value;
        }
    }
}
