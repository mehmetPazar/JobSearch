using Application.Wrappers;
using MediatR;

namespace Application.Features.ForbiddenWord.Queries.GetAllForbiddenWord;

public class GetAllForbiddenWordRequest : IRequest<ServiceResponse<List<GetAllForbiddenWordResponse>>>
{

}