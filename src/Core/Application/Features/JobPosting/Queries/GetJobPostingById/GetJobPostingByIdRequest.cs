using Application.Wrappers;
using MediatR;

namespace Application.Features.JobPosting.Queries.GetJobPostingById;

public class GetJobPostingByIdRequest : IRequest<ServiceResponse<GetJobPostingByIdResponse>>
{
    public long Id { get; set; }
}