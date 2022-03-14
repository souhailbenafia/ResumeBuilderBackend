using Application.DTOs.Certification;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Certification.Request.Queries
{
    public class GetCertificationDetailsRequest :  IRequest<CertificationDto>
    {
        public int Id { get; set; }
    }
}
