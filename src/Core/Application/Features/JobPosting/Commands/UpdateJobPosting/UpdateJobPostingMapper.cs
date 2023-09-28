using AutoMapper;

namespace Application.Features.JobPosting.Commands.UpdateJobPosting;

public class UpdateJobPostingMapper : Profile
{
	public UpdateJobPostingMapper()
	{
        CreateMap<UpdateJobPostingRequest, Domain.Entities.JobPosting>();
    }
}