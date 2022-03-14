using Application.Exceptions;
using Application.Features.Education.Request.Commands;
using Application.Persistence;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Education.Handlers.Commands
{
    public class DeleteEducationCommandHandler : IRequestHandler<DeleteEducationCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteEducationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
                _unitOfWork = unitOfWork; ;
                _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteEducationCommand request, CancellationToken cancellationToken)
        { 

            var education = await _unitOfWork.educationRepository.Get(request.Id);

            if (education == null)
                throw new NotFoundException(nameof(Education),request.Id);

            await _unitOfWork.educationRepository.Delete(education);
            await _unitOfWork.Save();

            return Unit.Value;

        }
    }
}
