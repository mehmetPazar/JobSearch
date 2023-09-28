using Application.Wrappers;
using MediatR;

namespace Application.Features.JobPosting.Queries.GetAllJobPosting;

public class GetAllJobPostingRequest : IRequest<ServiceResponse<List<GetAllJobPostingResponse>>>
{

}