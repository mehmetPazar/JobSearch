using Application.Wrappers;
using MediatR;

namespace Application.Features.ForbiddenWord.Commands.DeleteForbiddenWord;

public class DeleteForbiddenWordRequest : IRequest<ServiceResponse<long>>
{
    public long Id { get; set; }
}