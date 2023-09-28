using Application.Wrappers;
using Domain.Constants;
using MediatR;

namespace Application.Features.JobPosting.Commands.CreateJobPosting;

public class CreateJobPostingRequest : IRequest<ServiceResponse<long>>
{
    public string Position { get; set; }

    public string Description { get; set; }

    public DateTime ExpirationDate { get; set; }

    public int Quality { get; set; }

    public List<string> Benefits { get; set; }

    public EmploymentType Type { get; set; }

    public decimal Salary { get; set; }

    public long EmployerId { get; set; }
}