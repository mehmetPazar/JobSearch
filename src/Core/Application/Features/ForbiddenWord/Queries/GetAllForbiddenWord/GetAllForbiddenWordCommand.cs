using Application.Wrappers;
using AutoMapper;
using MediatR;
using Persistence.Repositories.Interfaces;

namespace Application.Features.ForbiddenWord.Queries.GetAllForbiddenWord;

public class GetAllForbiddenWordCommand : IRequestHandler<GetAllForbiddenWordRequest, ServiceResponse<List<GetAllForbiddenWordResponse>>>
{
    private readonly IForbiddenWordRepository _forbiddenWordRepository;
    private readonly IMapper _mapper;

    public GetAllForbiddenWordCommand(IForbiddenWordRepository forbiddenWordRepository, IMapper mapper)
    {
        _forbiddenWordRepository = forbiddenWordRepository;
        _mapper = mapper;
    }

    public async Task<ServiceResponse<List<GetAllForbiddenWordResponse>>> Handle(GetAllForbiddenWordRequest request, CancellationToken cancellationToken)
    {
        List<GetAllForbiddenWordResponse> forbiddenWords = _mapper.Map<List<GetAllForbiddenWordResponse>>(await _forbiddenWordRepository.GetAsync());
        return new ServiceResponse<List<GetAllForbiddenWordResponse>>(forbiddenWords) { IsSuccess = true };
    }
}