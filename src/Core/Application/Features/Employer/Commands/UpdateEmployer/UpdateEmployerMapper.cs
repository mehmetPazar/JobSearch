using AutoMapper;

namespace Application.Features.Employer.Commands.UpdateEmployer;

public class UpdateEmployerMapper : Profile
{
	public UpdateEmployerMapper()
	{
        CreateMap<UpdateEmployerRequest, Domain.Entities.Employer>();
    }
}