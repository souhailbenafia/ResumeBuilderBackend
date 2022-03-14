using Application.DTOs.Certification;
using Application.Features.Certification.Request.Queries;
using Application.Persistence;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Certification.Handlers.Queries
{
    public class GetCertificationDetailsRequestHandler : IRequestHandler<GetCertificationDetailsRequest, CertificationDto>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetCertificationDetailsRequestHandler(IUnitOfWork unitOfWork , IMapper mapper)
        {
            _unitOfWork = unitOfWork;   
            _mapper = mapper;
        }
        public async Task<CertificationDto> Handle(GetCertificationDetailsRequest request, CancellationToken cancellationToken)
        {
            var certification = await _unitOfWork.certificationRepository.Get(request.Id);
            return _mapper.Map<CertificationDto>(certification);
        }
    }
}
