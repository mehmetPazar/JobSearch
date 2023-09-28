using Application.Wrappers;
using MediatR;

namespace Application.Features.ForbiddenWord.Commands.CreateForbiddenWord;

public class CreateForbiddenWordRequest : IRequest<ServiceResponse<long>>
{
    public string Word { get; set; }
}