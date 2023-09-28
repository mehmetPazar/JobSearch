using AutoMapper;

namespace Application.Features.JobPosting.Commands.CreateJobPosting;

public class CreateJobPostingMapper : Profile
{
	public CreateJobPostingMapper()
	{
        CreateMap<CreateJobPostingRequest, Domain.Entities.JobPosting>();
    }
}