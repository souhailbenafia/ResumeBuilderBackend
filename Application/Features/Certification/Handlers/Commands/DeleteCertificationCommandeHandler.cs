using Application.Exceptions;
using Application.Features.Certification.Request;
using Application.Persistence;
using Application.Responses;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Certification.Handlers.Commands
{
    public class DeleteCertificationCommandeHandler : IRequestHandler<DeleteCertificationCommande>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public DeleteCertificationCommandeHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }

        public async Task<Unit> Handle(DeleteCertificationCommande request, CancellationToken cancellationToken)
        {
            var certification = await _unitOfWork.certificationRepository.Get(request.Id);
            if (certification == null)
                throw new NotFoundException(nameof(Domain.Entities.Certification),request.Id);

            await _unitOfWork.certificationRepository.Delete(certification);
            await _unitOfWork.Save();
            return Unit.Value;

        }


    }
}
