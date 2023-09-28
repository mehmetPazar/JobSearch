using AutoMapper;

namespace Application.Features.JobPosting.Queries.GetJobPostingById;

public class GetJobPostingByIdMapper : Profile
{
	public GetJobPostingByIdMapper()
	{
        CreateMap<Domain.Entities.JobPosting, GetJobPostingByIdResponse>();
    }
}