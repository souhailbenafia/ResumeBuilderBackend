using Application.DTOs.Language;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Language.Request.Queries
{
    public class GetLanguageListRequest : IRequest<List<LanguageDto>>
    {
        public string Id { get; set; }
    }
}
