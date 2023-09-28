using AutoMapper;

namespace Application.Features.Employer.Queries.GetEmployerById;

public class GetEmployerByIdMapper : Profile
{
	public GetEmployerByIdMapper()
	{
        CreateMap<Domain.Entities.Employer, GetEmployerByIdResponse>();
    }
}