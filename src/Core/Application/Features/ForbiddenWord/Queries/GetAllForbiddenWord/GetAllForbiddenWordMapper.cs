using AutoMapper;

namespace Application.Features.ForbiddenWord.Queries.GetAllForbiddenWord;

public class GetAllForbiddenWordMapper : Profile
{
	public GetAllForbiddenWordMapper()
	{
        CreateMap<Domain.Entities.ForbiddenWord, GetAllForbiddenWordResponse>();
    }
}