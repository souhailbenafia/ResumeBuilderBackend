﻿using Application.DTOs.Info;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Info.Request.Queries
{
    public class GetInfoListRequest : IRequest<List<InfoDto>>
    {
        public string Id { get; set; }
    }
}
