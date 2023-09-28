using Domain.Constants;

namespace Application.Features.JobPosting.Queries.GetJobPostingById;

public class GetJobPostingByIdResponse
{
    public long Id { get; set; }

    public string Position { get; set; }

    public string Description { get; set; }

    public DateTime ExpirationDate { get; set; }

    public int Quality { get; set; }

    public List<string> Benefits { get; set; }

    public EmploymentType Type { get; set; }

    public decimal Salary { get; set; }

    public long EmployerId { get; set; }
}