using AutoMapper;

namespace Application.Features.ForbiddenWord.Commands.UpdateForbiddenWord;

public class UpdateForbiddenWordMapper : Profile
{
	public UpdateForbiddenWordMapper()
	{
        CreateMap<UpdateForbiddenWordRequest, Domain.Entities.ForbiddenWord>();
    }
}