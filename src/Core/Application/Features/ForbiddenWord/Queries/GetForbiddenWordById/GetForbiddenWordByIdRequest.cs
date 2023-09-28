using Application.Wrappers;
using MediatR;

namespace Application.Features.ForbiddenWord.Queries.GetForbiddenWordById;

public class GetForbiddenWordByIdRequest : IRequest<ServiceResponse<GetForbiddenWordByIdResponse>>
{
    public long Id { get; set; }
}