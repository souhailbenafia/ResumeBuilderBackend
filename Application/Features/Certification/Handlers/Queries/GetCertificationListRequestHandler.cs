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
    public class GetCertificationListRequestHandler : IRequestHandler<GetCertificationListRequest, List<CertificationDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetCertificationListRequestHandler( IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;   
            _mapper = mapper; 
        }

        public async Task<List<CertificationDto>> Handle(GetCertificationListRequest request, CancellationToken cancellationToken)
        {
            var certifications = await _unitOfWork.certificationRepository.GetAll(); 
            return _mapper.Map<List<CertificationDto>>(certifications);
        }
    }
}
