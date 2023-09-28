using Application.Wrappers;
using MediatR;

namespace Application.Features.ForbiddenWord.Commands.UpdateForbiddenWord;

public class UpdateForbiddenWordRequest : IRequest<ServiceResponse<long>>
{
    public long Id { get; set; }

    public string Word { get; set; }
}