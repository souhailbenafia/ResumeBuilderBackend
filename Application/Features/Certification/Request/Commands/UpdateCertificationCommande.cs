using Application.DTOs.Certification;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Certification.Request.Commands
{
    public class UpdateCertificationCommande : IRequest
    {
        public CertificationDto certificationDto { get; set; }
    }
}
