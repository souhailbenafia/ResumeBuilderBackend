using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Certification.Request
{
    public class DeleteCertificationCommande : IRequest
    {
        public int Id { get; set; }


    }
}
