using AutoMapper;

namespace Application.Features.JobPosting.Queries.GetAllJobPosting;

public class GetAllJobPostingMapper : Profile
{
	public GetAllJobPostingMapper()
	{
        CreateMap<Domain.Entities.JobPosting, GetAllJobPostingResponse>();
    }
}