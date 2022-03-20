using Application.DTOs.Certification;
using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Certification.Request.Commands
{
    public class CreateCertificationCommande : IRequest<BaseCommandResponse>
    {
        public CreateCertificationDto createCertificationDto { get; set; }
    }
}
