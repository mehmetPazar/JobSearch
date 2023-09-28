using Application.Wrappers;
using AutoMapper;
using MediatR;
using Persistence.Repositories.Interfaces;

namespace Application.Features.ForbiddenWord.Queries.GetForbiddenWordById;

public class GetForbiddenWordByIdCommand : IRequestHandler<GetForbiddenWordByIdRequest, ServiceResponse<GetForbiddenWordByIdResponse>>
{
    private readonly IForbiddenWordRepository _forbiddenWordRepository;
    private readonly IMapper _mapper;

    public GetForbiddenWordByIdCommand(IForbiddenWordRepository forbiddenWordRepository, IMapper mapper)
    {
        _forbiddenWordRepository = forbiddenWordRepository;
        _mapper = mapper;
    }

    public async Task<ServiceResponse<GetForbiddenWordByIdResponse>> Handle(GetForbiddenWordByIdRequest request, CancellationToken cancellationToken)
    {
        GetForbiddenWordByIdResponse forbiddenWord = _mapper.Map<GetForbiddenWordByIdResponse>(await _forbiddenWordRepository.GetByIdAsync(request.Id));
        return new ServiceResponse<GetForbiddenWordByIdResponse>(forbiddenWord) { IsSuccess = true };
    }
}