using Application.Wrappers;
using MediatR;
using Persistence.Repositories.Interfaces;

namespace Application.Features.ForbiddenWord.Commands.DeleteForbiddenWord;

public class DeleteForbiddenWordCommand : IRequestHandler<DeleteForbiddenWordRequest, ServiceResponse<long>>
{
    private readonly IForbiddenWordRepository _forbiddenWordRepository;

    public DeleteForbiddenWordCommand(IForbiddenWordRepository forbiddenWordRepository)
    {
        _forbiddenWordRepository = forbiddenWordRepository;
    }

    public async Task<ServiceResponse<long>> Handle(DeleteForbiddenWordRequest request, CancellationToken cancellationToken)
    {
        bool isSuccess = await _forbiddenWordRepository.RemoveAsync(request.Id);
        return new ServiceResponse<long>(request.Id) { IsSuccess = isSuccess };
    }
}