using Application.Persistence;
using MediatR;
using AutoMapper;
using Application.Features.Language.Request.Queries;
using Application.DTOs.Language;

namespace Application.Features.LeaveTypes.Handlers.Queries
{
    public class GetLanguageListRequestHandler : IRequestHandler<GetLanguageListRequest, List<LanguageDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetLanguageListRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<LanguageDto>> Handle(GetLanguageListRequest request, CancellationToken cancellationToken)
        {
            var languages = await _unitOfWork.languageRepository.GetAll();
            return _mapper.Map<List<LanguageDto>>(languages);
        }
    }
}
