using Application.Wrappers;
using AutoMapper;
using MediatR;
using Persistence.Repositories.Interfaces;

namespace Application.Features.ForbiddenWord.Commands.UpdateForbiddenWord;

public class UpdateForbiddenWordCommand : IRequestHandler<UpdateForbiddenWordRequest, ServiceResponse<long>>
{
    private readonly IForbiddenWordRepository _forbiddenWordRepository;
    private readonly IMapper _mapper;

    public UpdateForbiddenWordCommand(IForbiddenWordRepository forbiddenWordRepository, IMapper mapper)
    {
        _forbiddenWordRepository = forbiddenWordRepository;
        _mapper = mapper;
    }

    public async Task<ServiceResponse<long>> Handle(UpdateForbiddenWordRequest request, CancellationToken cancellationToken)
    {
        Domain.Entities.ForbiddenWord updateForbiddenWord = _mapper.Map<Domain.Entities.ForbiddenWord>(request);
        updateForbiddenWord.LastModifiedBy = "ADMIN";
        updateForbiddenWord.LastModified = new DateTime();

        bool isSuccess = await _forbiddenWordRepository.UpdateAsync(updateForbiddenWord, request.Id);
        return new ServiceResponse<long>(request.Id) { IsSuccess = isSuccess };
    }
}