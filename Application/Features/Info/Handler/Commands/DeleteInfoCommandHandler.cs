using Application.Exceptions;
using Application.Features.Info.Request.Commands;
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
    public class DeleteInfoCommandHandler : IRequestHandler<DeleteInfoCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteInfoCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }
        public async  Task<Unit> Handle(DeleteInfoCommand request, CancellationToken cancellationToken)
        {
            var info = await _unitOfWork.infoRepository.Get(request.Id);
            if (info == null) throw new NotFoundException(nameof(info), request.Id);

            await _unitOfWork.infoRepository.Delete(info);
            await _unitOfWork.Save();
            return Unit.Value;
        }
    }
}
