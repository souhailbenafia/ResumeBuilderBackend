using Application.DTOs.Certification;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Certification.Request.Queries
{
    public class GetCertificationListRequest : IRequest<List<CertificationDto>>
    {
        public string Id { get; set; }
    }
}
