using Application.Exceptions;
using Application.Features.Skill.Request.Commands;
using Application.Persistence;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Skill.Handlers.Commands
{
    public class DeleteSkilllCommandHandler : IRequestHandler<DeleteSKillCommand>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteSkilllCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

     
        public async Task<Unit> Handle(DeleteSKillCommand request, CancellationToken cancellationToken)
        {
            var skill = await _unitOfWork.skillRepository.Get(request.Id);

            if (skill == null)
                throw new NotFoundException(nameof(skill), request.Id);

            await _unitOfWork.skillRepository.Delete(skill);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}