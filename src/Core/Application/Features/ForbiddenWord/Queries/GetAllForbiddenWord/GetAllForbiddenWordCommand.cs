using Persistence.Repositories.Interfaces;
using Application.Wrappers;
using AutoMapper;
using MediatR;

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
        try
        {
            List<GetAllForbiddenWordResponse> forbiddenWords = _mapper.Map<List<GetAllForbiddenWordResponse>>(await _forbiddenWordRepository.GetAsync());
            return new ServiceResponse<List<GetAllForbiddenWordResponse>>(forbiddenWords) { IsSuccess = true };
        }
        catch (Exception ex)
        {
            return new ServiceResponse<List<GetAllForbiddenWordResponse>>(null) { IsSuccess = false, Message = ex.Message.ToString() };
        }
    }
}