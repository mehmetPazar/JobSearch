using AutoMapper;

namespace Application.Features.ForbiddenWord.Commands.CreateForbiddenWord;

public class CreateForbiddenWordMapper : Profile
{
	public CreateForbiddenWordMapper()
	{
        CreateMap<CreateForbiddenWordRequest, Domain.Entities.ForbiddenWord>();
    }
}