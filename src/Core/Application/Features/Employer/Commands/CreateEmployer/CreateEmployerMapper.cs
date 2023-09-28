using AutoMapper;

namespace Application.Features.Employer.Commands.CreateEmployer;

public class CreateEmployerMapper : Profile
{
	public CreateEmployerMapper()
	{
        CreateMap<CreateEmployerRequest, Domain.Entities.Employer>();
    }
}