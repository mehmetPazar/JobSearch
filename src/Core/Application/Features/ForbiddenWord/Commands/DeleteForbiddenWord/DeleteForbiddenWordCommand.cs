using Persistence.Repositories.Interfaces;
using Application.Wrappers;
using MediatR;

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
        try
        {
            bool isSuccess = await _forbiddenWordRepository.RemoveAsync(request.Id);

            if (isSuccess)
            {
                return new ServiceResponse<long>(request.Id) { IsSuccess = isSuccess };
            }
            else
            {
                return new ServiceResponse<long>(request.Id) { IsSuccess = isSuccess, Message = "An error occurred while performing the delete request." };
            }
        }
        catch (Exception ex)
        {
            return new ServiceResponse<long>(request.Id) { IsSuccess = false, Message = ex.Message.ToString() };
        }
    }
}