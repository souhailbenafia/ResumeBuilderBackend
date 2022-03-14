using Application.Exceptions;
using Application.Features.Experience.Request.Commands;
using Application.Persistence;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Experience.Handlers.Commands
{
    public class DeleteExperianceCommandHandler : IRequestHandler<DeleteExperianceCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteExperianceCommandHandler( IUnitOfWork unitOfWork , IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;   

        }
        async Task<Unit> IRequestHandler<DeleteExperianceCommand, Unit>.Handle(DeleteExperianceCommand request, CancellationToken cancellationToken)
        {
            var Experiance = await _unitOfWork.experianceRepository.Get(request.Id);
            if (Experiance == null)throw new NotFoundException(nameof(Experiance),request.Id);

            await _unitOfWork.experianceRepository.Delete(Experiance);
            await _unitOfWork.Save();
            return Unit.Value;

           
        }
    }
}
