using AutoMapper;

namespace Application.Features.ForbiddenWord.Queries.GetForbiddenWordById;

public class GetForbiddenWordByIdMapper : Profile
{
	public GetForbiddenWordByIdMapper()
	{
        CreateMap<Domain.Entities.ForbiddenWord, GetForbiddenWordByIdResponse>();
    }
}