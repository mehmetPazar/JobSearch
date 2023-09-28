using Application.Wrappers;
using MediatR;

namespace Application.Features.JobPosting.Commands.DeleteJobPosting;

public class DeleteJobPostingRequest : IRequest<ServiceResponse<long>>
{
    public long Id { get; set; }
}