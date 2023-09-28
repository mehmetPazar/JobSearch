using AutoMapper;

namespace Application.Features.Employer.Queries.GetAllEmployer;

public class GetAllEmployerMapper : Profile
{
	public GetAllEmployerMapper()
	{
        CreateMap<Domain.Entities.Employer, GetAllEmployerResponse>();
    }
}