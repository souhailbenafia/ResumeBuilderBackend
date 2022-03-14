using Application.Persistence;
using MediatR;
using AutoMapper;
using Application.Features.Language.Request.Queries;
using Application.DTOs.Language;

namespace Application.Features.LeaveTypes.Handlers.Queries
{
    public class GetLanguageDetailRequestHandler : IRequestHandler<GetLanguageDetailRequest, LanguageDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetLanguageDetailRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
           _unitOfWork= unitOfWork;
            _mapper = mapper;
        }
        public async Task<LanguageDto> Handle(GetLanguageDetailRequest request, CancellationToken cancellationToken)
        {
            var language = await _unitOfWork.languageRepository.Get(request.Id);
            return _mapper.Map<LanguageDto>(language);
        }
    }
}
