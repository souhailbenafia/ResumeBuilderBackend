using Application.DTOs.Info;
using Application.Features.Info.Request.Queries;
using Application.Features.Interest.Request.Queries;
using Application.Persistence;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Info.Handler.Queries
{
    public class GetInfoListRequestHandler : IRequestHandler<GetInfoListRequest, List<InfoDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetInfoListRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        

        public  async Task<List<InfoDto>> Handle(GetInfoListRequest request, CancellationToken cancellationToken)
        {
            var info = await _unitOfWork.infoRepository.GetAllCertificationByUser(request.Id);
            return _mapper.Map<List<InfoDto>>(info);
        }
    }
}
